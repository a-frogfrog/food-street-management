using FSM.Api.Admin.Configs;
using FSM.Api.Admin.Filters;
using FSM.Api.Admin.Options;
using FSM.Api.Admin.utils;
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

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor(); // 注入HttpContextAccessor
builder.Services.AddHttpClient();

#region Dependency injection
//���ݿ�������ע�� MySql
builder.Services.AddScoped<DbContext, FSM.Infrastructure.EFCore.MySql.Models.fsmdbContext>();
builder.Services.AddDbContextPool<FSM.Infrastructure.EFCore.MySql.Models.fsmdbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("MySQL"),
        new MySqlServerVersion(new Version(8, 0, 40)),
        provider =>
        {
            provider.CommandTimeout(20);
        });
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}, poolSize: 64);
//�ִ�ע��
builder.Services.AddScoped(typeof(IRepository<>), typeof(MySqlRepository<>));
//�ֿ�ʵ��ע��
builder.Services.AddScoped(Assembly.Load("FSM.Repository.EntityRepositories"), Assembly.Load("FSM.Repository.EntityRepositories"));
//��������ע��
builder.Services.AddScoped(Assembly.Load("FSM.Service.Dependencies"), Assembly.Load("FSM.Service.Dependencies"));
//����ע��
builder.Services.AddScoped(Assembly.Load("FSM.Service.Interface"), Assembly.Load("FSM.Service.Instance"));
//������ע��
builder.Services.AddScoped(Assembly.Load("FSM.Infrastructure.Tools"), Assembly.Load("FSM.Infrastructure.Tools"));
//������ע��
builder.Services.AddSingleton(Assembly.Load("FSM.Infrastructure.Helpers"), Assembly.Load("FSM.Infrastructure.Helpers"));
//����ע��
builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection(AuthOptions.SectionName));
var fileStorageConfig = FileStorageConfig.LoadConfig(builder.Configuration);
builder.Services.AddSingleton(fileStorageConfig);
var fileUploadConfig = FileUploadConfig.LoadConfig(builder.Configuration);
builder.Services.AddSingleton(fileUploadConfig);
#endregion

#region Cors
//Corss
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins(
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
//����Swagger
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
            Description = "Food Street Management Api �ӿ��ĵ�",
            Contact = new OpenApiContact
            {
                Name = "FrogFrog",
                Email = "a_frogfrog@outlook.com",
            }
        });

        string basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location)!;
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "FSM.Api.Admin.xml"), true);
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "FSM.Infrastructure.Dto.xml"), true);

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�,��ȷ��ʽΪ Bearer+�ո�+Token��\"",
            Name = "Authorization",//jwtĬ�ϵĲ�������
            In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
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

               }, Array.Empty<string>()
            }
        });

    });
}

#endregion

#region Authentication
// ����JWT ��Ȩ
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
        //��֤ token
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {

                var authorization = context.Request.Headers["Authorization"].ToString();
                if (!string.IsNullOrEmpty(authorization))
                {
                    try
                    {
                        var header = new JwtSecurityTokenHandler();
                        var token = header.ReadJwtToken(authorization.Replace("Bearer ", ""));
                        string payload = token.Claims.ToList().First(f => f.Type == ClaimTypes.Name).Value.ToString();
                        //��֤payload
                        var _authService = context.HttpContext.RequestServices.GetService<IAuthService>();
                        var result = _authService!.ValidateToken(payload);
                        if (!result)
                        {
                            context.Request.Headers["Authorization"] = string.Empty;
                            //context.Response.StatusCode = 200;
                            //context.Response.WriteAsJsonAsync(ResponseHelper.Unauthorized());
                        }
                    }
                    catch (Exception)
                    {

                        context.Request.Headers["Authorization"] = string.Empty;
                        //context.Response.StatusCode = 200;
                        //context.Response.WriteAsJsonAsync(ResponseHelper.Unauthorized());
                    }
                }


                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddAuthorization();

#endregion

#region Filter
//���ӹ�����
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(PermissionFilter));
    options.Filters.Add(typeof(ResponseFilter));
    options.Filters.Add(typeof(OperationFilter));
});
#endregion


// ForwardedHeaders
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();  // 信任所有代理
    options.KnownProxies.Clear();
});
// ���ӽ������
builder.Services.AddHealthChecks();

var app = builder.Build();
app.UseForwardedHeaders();


if (app.Environment.IsEnvironment("development"))
{
    app.Urls.Add("http://localhost:9527");
}
else {
    app.Urls.Add("http://*:9527");
}



    //app.UseMiddleware<ExceptionHandlerMiddleware>();

    // Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseKnife4UI(d =>
{
    d.RoutePrefix = String.Empty;
    d.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");//Endpoint �ն��м��
});


//���ӿ���
app.UseCors("CorsPolicy");
//��Ȩ�м��
app.UseAuthentication();
app.UseAuthorization();

//ӳ��ͼƬ�ļ�Ŀ¼
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider
    (Path.Combine(Directory.GetCurrentDirectory(), fileStorageConfig.GetImageDirectory())),
    RequestPath = $"/{fileStorageConfig.ImagePath}",
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Cache-Control", "public, max-age=86400");
    }
});

app.MapControllers();

app.Run();
