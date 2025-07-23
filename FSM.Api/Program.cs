using FSM.Api.Configs;
using FSM.Api.Filters;
using FSM.Api.MiddleWares;
using FSM.Api.Options;
using FSM.Api.utils;
using FSM.Repository.Instance;
using FSM.Repository.Interface;
using FSM.Service.Instance;
using FSM.Service.Interface;
using IGeekFan.AspNetCore.Knife4jUI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Services
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor(); // 注入HttpContextAccessor
builder.Services.AddHttpClient();

// ForwardedHeaders
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear(); // 信任所有代理
    options.KnownProxies.Clear();
});

//健康检查
builder.Services.AddHealthChecks();

//配置文件
builder.Configuration
    .AddJsonFile($"appsettings{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddJsonFile("appsettings.Service.json", optional: true,reloadOnChange:true)
    .AddEnvironmentVariables()
    .AddCommandLine(args);
#endregion

#region Dependency injection

// 数据库上下文
builder.Services.AddScoped<DbContext, FSM.Infrastructure.EFCore.MySql.Models.fsmdbContext>();
//数据库连接
builder.Services.AddDbContextPool<FSM.Infrastructure.EFCore.MySql.Models.fsmdbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("MySQL"),
        new MySqlServerVersion(new Version(8, 0, 40)),
        provider => { provider.CommandTimeout(20); });
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}, poolSize: 64);
//仓储
builder.Services.AddScoped(typeof(IRepository<>), typeof(MySqlRepository<>));
//仓储类
builder.Services.AddScoped(Assembly.Load("FSM.Repository.EntityRepositories"),
    Assembly.Load("FSM.Repository.EntityRepositories"));
//Redis服务
builder.Services.AddScoped(Assembly.Load("FSM.Infrastructure.Redis"),Assembly.Load("FSM.Infrastructure.Redis"));
//服务依赖
builder.Services.AddScoped(Assembly.Load("FSM.Service.Dependencies"), Assembly.Load("FSM.Service.Dependencies"));
//服务实现
builder.Services.AddScoped(Assembly.Load("FSM.Service.Interface"), Assembly.Load("FSM.Service.Instance"));
//工具类
builder.Services.AddScoped(Assembly.Load("FSM.Infrastructure.Tools"), Assembly.Load("FSM.Infrastructure.Tools"));
//帮助类
builder.Services.AddSingleton(Assembly.Load("FSM.Infrastructure.Helpers"), Assembly.Load("FSM.Infrastructure.Helpers"));
//全局状态类
builder.Services.AddSingleton(Assembly.Load("FSM.Infrastructure.Status"), Assembly.Load("FSM.Infrastructure.Status"));
//配置
builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection(AuthOptions.SectionName));
var fileStorageConfig = FileStorageConfig.LoadConfig(builder.Configuration);
builder.Services.AddSingleton(fileStorageConfig);
var fileUploadConfig = FileUploadConfig.LoadConfig(builder.Configuration);
builder.Services.AddSingleton(fileUploadConfig);

#endregion

#region Cors

//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173",
                "http://localhost:4173",
                "http://admin.fsm.frogfrog.cn",
                "https://admin.fsm.frogfrog.cn"
            ).AllowAnyHeader()
            .AllowAnyMethod()
            .SetPreflightMaxAge(TimeSpan.FromHours(1));
    });
});

#endregion

#region Swagger

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
if (builder.Environment.IsEnvironment("Development"))
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo()
        {
            Title = "Food Street Management Api",
            Version = "v1.0",
            Description = "Food Street Management Api",
            Contact = new OpenApiContact
            {
                Name = "FrogFrog",
                Email = "a_frogfrog@outlook.com",
            }
        });

        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "FSM.Api.xml"), true);
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "FSM.Infrastructure.Dto.xml"), true);

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description =
                "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�,��ȷ��ʽΪ Bearer+�ո�+Token��\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference()
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        });
    });
}

#endregion

#region Authentication

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
            ClockSkew = TimeSpan.Zero
        };
        //验证 token
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var authorization = context.Request.Headers["Authorization"].ToString();
                if (string.IsNullOrEmpty(authorization))
                {
                    context.Request.Headers["Authorization"] = string.Empty;
                }

                try
                {
                    var header = new JwtSecurityTokenHandler();
                    var token = header.ReadJwtToken(authorization.Replace("Bearer ", ""));
                    var payload = token.Claims.ToList().First(f => f.Type == ClaimTypes.Name).Value.ToString();
                    //payload
                    var authService = context.HttpContext.RequestServices.GetService<IAuthService>();
                    var result = authService!.ValidateToken(payload);
                    if (!result)
                    {
                        context.Request.Headers["Authorization"] = string.Empty;
                    }
                }
                catch (Exception)
                {
                    context.Request.Headers["Authorization"] = string.Empty;
                }


                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddAuthorization();

#endregion

#region Filter

//全局Filter
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(PermissionFilter));
    options.Filters.Add(typeof(ResponseFilter));
    options.Filters.Add(typeof(OperationFilter));
});

#endregion




var app = builder.Build();

//配置运行端口
if (app.Environment.IsDevelopment())
{
    app.Urls.Add("http://localhost:9527");
}

app.Urls.Add("http://*:9527");

//代理头
app.UseForwardedHeaders();

//静态文件
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider
        (Path.Combine(Directory.GetCurrentDirectory(), fileStorageConfig.GetImageDirectory())),
    RequestPath = $"/{fileStorageConfig.ImagePath}",
    OnPrepareResponse = ctx => { ctx.Context.Response.Headers.Append("Cache-Control", "public, max-age=86400"); }
});

//跨域
app.UseCors("CorsPolicy");


//路由
app.UseRouting();


//鉴权
app.UseAuthentication();
app.UseAuthorization();

//异常中间件
//app.UseMiddleware<ExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseKnife4UI(d =>
{
    d.RoutePrefix = String.Empty;
    d.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.MapControllers();

app.Run();