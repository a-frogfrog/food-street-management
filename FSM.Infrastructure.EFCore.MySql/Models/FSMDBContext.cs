using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FSM.Infrastructure.EFCore.MySql.Models
{
    public partial class fsmdbContext : DbContext
    {
        public fsmdbContext()
        {
        }

        public fsmdbContext(DbContextOptions<fsmdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dictionary> Dictionaries { get; set; } = null!;
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; } = null!;
        public virtual DbSet<LoginLog> LoginLogs { get; set; } = null!;
        public virtual DbSet<Merchant> Merchants { get; set; } = null!;
        public virtual DbSet<MerchantLoginLog> MerchantLoginLogs { get; set; } = null!;
        public virtual DbSet<OperationLog> OperationLogs { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<SupplierLoginLog> SupplierLoginLogs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserPermission> UserPermissions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=ConnectionStrings:MySQL", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Dictionary>(entity =>
            {
                entity.ToTable("dictionary");

                entity.HasComment("字典表 (存储状态，类型等)");

                entity.HasIndex(e => e.Code, "code")
                    .IsUnique();

                entity.Property(e => e.DictionaryId)
                    .HasMaxLength(32)
                    .HasColumnName("dictionaryId")
                    .HasComment("字典ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .HasColumnName("code")
                    .HasComment("字典名称");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.Description)
                    .HasMaxLength(999)
                    .HasColumnName("description")
                    .HasComment("描述");

                entity.Property(e => e.DictionaryName)
                    .HasMaxLength(50)
                    .HasColumnName("dictionaryName")
                    .HasComment("字典名称");

                entity.Property(e => e.DictionaryValue)
                    .HasMaxLength(256)
                    .HasColumnName("dictionaryValue")
                    .HasComment("字典value");

                entity.Property(e => e.IsNode)
                    .HasColumnName("isNode")
                    .HasComment("是否为节点");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasComment("层级");

                entity.Property(e => e.ParentId)
                    .HasMaxLength(32)
                    .HasColumnName("parentId")
                    .HasComment("父级字典ID，为子级字典特有字段");

                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serialNumber")
                    .HasComment("字典序号");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("修改时间");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PRIMARY");

                entity.ToTable("error_logs");

                entity.HasComment("错误日志表");

                entity.Property(e => e.LogId)
                    .HasMaxLength(32)
                    .HasColumnName("logId")
                    .HasComment("日志ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasComment("创建时间");

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(50)
                    .HasColumnName("errorCode")
                    .HasComment("错误Code");

                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(256)
                    .HasColumnName("errorMessage")
                    .HasComment("错误消息");

                entity.Property(e => e.ErrorType)
                    .HasMaxLength(256)
                    .HasColumnName("errorType")
                    .HasComment("错误类型");

                entity.Property(e => e.HttpStatusCode)
                    .HasColumnName("httpStatusCode")
                    .HasComment("HTTP请求状态码");

                entity.Property(e => e.StackTrace)
                    .HasColumnType("text")
                    .HasColumnName("stackTrace")
                    .HasComment("堆栈信息");
            });

            modelBuilder.Entity<LoginLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PRIMARY");

                entity.ToTable("login_logs");

                entity.HasComment("管理员登录日志表");

                entity.Property(e => e.LogId)
                    .HasMaxLength(32)
                    .HasColumnName("logId")
                    .HasComment("日志ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasComment("创建时间");

                entity.Property(e => e.ErrorMessage)
                    .HasColumnType("text")
                    .HasColumnName("errorMessage")
                    .HasComment("错误信息");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(50)
                    .HasColumnName("ipAddress")
                    .HasComment("IP地址");

                entity.Property(e => e.Location)
                    .HasColumnType("text")
                    .HasColumnName("location")
                    .HasComment("IP地址转换为实际地址");

                entity.Property(e => e.LoginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("loginTime")
                    .HasComment("登录时间");

                entity.Property(e => e.LoginType)
                    .HasMaxLength(50)
                    .HasColumnName("loginType")
                    .HasComment("登录类型");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(32)
                    .HasColumnName("sessionId")
                    .HasComment("会话ID");

                entity.Property(e => e.Source)
                    .HasMaxLength(20)
                    .HasColumnName("source")
                    .HasComment("登录来源（PC端，移动端等）");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态（是否成功）");

                entity.Property(e => e.UserAgent)
                    .HasColumnType("text")
                    .HasColumnName("userAgent")
                    .HasComment("用户设备信息");

                entity.Property(e => e.UserId)
                    .HasMaxLength(32)
                    .HasColumnName("userId")
                    .HasComment("用户ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("userName")
                    .HasComment("用户名称");
            });

            modelBuilder.Entity<Merchant>(entity =>
            {
                entity.HasKey(e => e.MerchId)
                    .HasName("PRIMARY");

                entity.ToTable("merchants");

                entity.HasComment("商户表");

                entity.Property(e => e.MerchId)
                    .HasMaxLength(32)
                    .HasColumnName("merchId")
                    .HasComment("商户ID");

                entity.Property(e => e.Account)
                    .HasMaxLength(11)
                    .HasColumnName("account")
                    .HasComment("账号");

                entity.Property(e => e.BusinessLicense)
                    .HasMaxLength(100)
                    .HasColumnName("businessLicense")
                    .HasComment("营业执照编号");

                entity.Property(e => e.Contacts)
                    .HasMaxLength(32)
                    .HasColumnName("contacts")
                    .HasComment("联系人");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .HasMaxLength(999)
                    .HasColumnName("description")
                    .HasComment("备注");

                entity.Property(e => e.MerchName)
                    .HasMaxLength(50)
                    .HasColumnName("merchName")
                    .HasComment("商户名称");

                entity.Property(e => e.MerchType)
                    .HasMaxLength(32)
                    .HasColumnName("merchType")
                    .HasComment("商户类型");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(32)
                    .HasColumnName("passwordHash")
                    .HasComment("密码哈希值");

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(32)
                    .HasColumnName("passwordSalt")
                    .HasComment("密码盐值");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<MerchantLoginLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PRIMARY");

                entity.ToTable("merchant_login_logs");

                entity.HasComment("商户登录日志表");

                entity.Property(e => e.LogId)
                    .HasMaxLength(32)
                    .HasColumnName("logId")
                    .HasComment("日志ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasComment("创建时间");

                entity.Property(e => e.ErrorMessage)
                    .HasColumnType("text")
                    .HasColumnName("errorMessage")
                    .HasComment("错误信息");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(50)
                    .HasColumnName("ipAddress")
                    .HasComment("IP地址");

                entity.Property(e => e.Location)
                    .HasColumnType("text")
                    .HasColumnName("location")
                    .HasComment("IP地址转换为实际地址");

                entity.Property(e => e.LoginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("loginTime")
                    .HasComment("登录时间");

                entity.Property(e => e.LoginType)
                    .HasMaxLength(50)
                    .HasColumnName("loginType")
                    .HasComment("登录类型");

                entity.Property(e => e.MerchId)
                    .HasMaxLength(32)
                    .HasColumnName("merchId")
                    .HasComment("商户ID");

                entity.Property(e => e.MerchName)
                    .HasMaxLength(50)
                    .HasColumnName("merchName")
                    .HasComment("商户名称");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(32)
                    .HasColumnName("sessionId")
                    .HasComment("会话ID");

                entity.Property(e => e.Source)
                    .HasMaxLength(20)
                    .HasColumnName("source")
                    .HasComment("登录来源（PC端，移动端等）");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态（是否成功）");

                entity.Property(e => e.UserAgent)
                    .HasColumnType("text")
                    .HasColumnName("userAgent")
                    .HasComment("用户设备信息");
            });

            modelBuilder.Entity<OperationLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PRIMARY");

                entity.ToTable("operation_logs");

                entity.HasComment("操作日志表");

                entity.Property(e => e.LogId)
                    .HasMaxLength(32)
                    .HasColumnName("logId")
                    .HasComment("日志ID");

                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .HasColumnName("action")
                    .HasComment("行为");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(50)
                    .HasColumnName("ipAddress")
                    .HasComment("IP地址");

                entity.Property(e => e.Location)
                    .HasColumnType("text")
                    .HasColumnName("location")
                    .HasComment("IP地址转换为实际地址");

                entity.Property(e => e.Method)
                    .HasMaxLength(20)
                    .HasColumnName("method")
                    .HasComment("HTTP请求方法");

                entity.Property(e => e.Module)
                    .HasMaxLength(50)
                    .HasColumnName("module")
                    .HasComment("操作模块");

                entity.Property(e => e.ModuleUrl)
                    .HasMaxLength(256)
                    .HasColumnName("moduleUrl")
                    .HasComment("模块地址");

                entity.Property(e => e.OperationTime)
                    .HasColumnType("datetime")
                    .HasColumnName("operationTime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperationType)
                    .HasMaxLength(50)
                    .HasColumnName("operationType")
                    .HasComment("操作类型");

                entity.Property(e => e.Parameters)
                    .HasMaxLength(999)
                    .HasColumnName("parameters")
                    .HasComment("参数");

                entity.Property(e => e.Remark)
                    .HasMaxLength(256)
                    .HasColumnName("remark")
                    .HasComment("备注");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态，是否成功");

                entity.Property(e => e.UserAgent)
                    .HasColumnType("text")
                    .HasColumnName("userAgent")
                    .HasComment("用户设备信息");

                entity.Property(e => e.UserId)
                    .HasMaxLength(32)
                    .HasColumnName("userId")
                    .HasComment("用户ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("userName")
                    .HasComment("用户名称");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrederId)
                    .HasName("PRIMARY");

                entity.ToTable("orders");

                entity.HasComment("订单表");

                entity.Property(e => e.OrederId)
                    .HasMaxLength(32)
                    .HasColumnName("orederId")
                    .HasComment("订单ID");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasComment("类别");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasComment("数量");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.IsComplete)
                    .HasColumnName("isComplete")
                    .HasComment("是否完成");

                entity.Property(e => e.IsPay)
                    .HasColumnName("isPay")
                    .HasComment("是否支付");

                entity.Property(e => e.IsReceive)
                    .HasColumnName("isReceive")
                    .HasComment("是否收货");

                entity.Property(e => e.IsSend)
                    .HasColumnName("isSend")
                    .HasComment("是否发货");

                entity.Property(e => e.MerchantId)
                    .HasMaxLength(32)
                    .HasColumnName("merchantId")
                    .HasComment("商户ID");

                entity.Property(e => e.Money)
                    .HasColumnName("money")
                    .HasComment("金额");

                entity.Property(e => e.PayTime)
                    .HasColumnType("datetime")
                    .HasColumnName("payTime")
                    .HasComment("支付时间");

                entity.Property(e => e.SupplierId)
                    .HasMaxLength(32)
                    .HasColumnName("supplierId")
                    .HasComment("供应商ID");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.DetailId)
                    .HasName("PRIMARY");

                entity.ToTable("order_details");

                entity.HasComment("订单详情表");

                entity.Property(e => e.DetailId)
                    .HasMaxLength(32)
                    .HasColumnName("detailId")
                    .HasComment("详情ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(32)
                    .HasColumnName("orderId")
                    .HasComment("订单ID");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasComment("价格");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(32)
                    .HasColumnName("productId")
                    .HasComment("商品ID");

                entity.Property(e => e.ProductImageUrl)
                    .HasMaxLength(500)
                    .HasColumnName("productImageUrl")
                    .HasComment("商品图表地址");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(256)
                    .HasColumnName("productName")
                    .HasComment("商品名称");

                entity.Property(e => e.PromotionId)
                    .HasMaxLength(32)
                    .HasColumnName("promotionId")
                    .HasComment("活动ID/不是活动为null");

                entity.Property(e => e.PurchaseQuantity)
                    .HasColumnName("purchaseQuantity")
                    .HasComment("购买数量");

                entity.Property(e => e.Specification)
                    .HasMaxLength(20)
                    .HasColumnName("specification")
                    .HasComment("规格");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasComment("小计");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.PermId)
                    .HasName("PRIMARY");

                entity.ToTable("permissions");

                entity.HasComment("权限表");

                entity.Property(e => e.PermId)
                    .HasMaxLength(32)
                    .HasColumnName("permId")
                    .HasComment("权限ID");

                entity.Property(e => e.CrateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("crateTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.Description)
                    .HasMaxLength(999)
                    .HasColumnName("description")
                    .HasComment("描述");

                entity.Property(e => e.Icon)
                    .HasMaxLength(256)
                    .HasColumnName("icon")
                    .HasComment("权限图标");

                entity.Property(e => e.ParentId)
                    .HasMaxLength(32)
                    .HasColumnName("parentId")
                    .HasComment("父级权限");

                entity.Property(e => e.PermName)
                    .HasMaxLength(50)
                    .HasColumnName("permName")
                    .HasComment("权限名称");

                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serialNumber")
                    .HasComment("序号");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("权限状态");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("权限类型");

                entity.Property(e => e.Url)
                    .HasMaxLength(256)
                    .HasColumnName("url")
                    .HasComment("权限地址");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasComment("商品主表");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(32)
                    .HasColumnName("productId")
                    .HasComment("商品ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间（自动生成）");

                entity.Property(e => e.Description)
                    .HasMaxLength(999)
                    .HasColumnName("description")
                    .HasComment("商品描述");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasComment("单价");

                entity.Property(e => e.ProductCategory)
                    .HasMaxLength(32)
                    .HasColumnName("productCategory")
                    .HasComment("商品类别");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .HasColumnName("productName")
                    .HasComment("商品名称");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("商品状态");

                entity.Property(e => e.SupplierId)
                    .HasMaxLength(32)
                    .HasColumnName("supplierId")
                    .HasComment("关联的供应商ID");

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .HasColumnName("unit")
                    .HasComment("单位/规格（kg/件/箱）");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SuppId)
                    .HasName("PRIMARY");

                entity.ToTable("suppliers");

                entity.HasComment("供应商表");

                entity.Property(e => e.SuppId)
                    .HasMaxLength(32)
                    .HasColumnName("suppId")
                    .HasComment("供应商ID");

                entity.Property(e => e.Account)
                    .HasMaxLength(11)
                    .HasColumnName("account")
                    .HasComment("账号");

                entity.Property(e => e.Contacts)
                    .HasMaxLength(32)
                    .HasColumnName("contacts")
                    .HasComment("联系人");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.Description)
                    .HasMaxLength(999)
                    .HasColumnName("description")
                    .HasComment("备用");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(32)
                    .HasColumnName("passwordHash")
                    .HasComment("密码");

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(32)
                    .HasColumnName("passwordSalt")
                    .HasComment("密码盐值");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.SuppName)
                    .HasMaxLength(50)
                    .HasColumnName("suppName")
                    .HasComment("供应商名称");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updateTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("修改时间");
            });

            modelBuilder.Entity<SupplierLoginLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PRIMARY");

                entity.ToTable("supplier_login_logs");

                entity.HasComment("供应商登录日志表");

                entity.Property(e => e.LogId)
                    .HasMaxLength(32)
                    .HasColumnName("logId")
                    .HasComment("日志ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.ErrorMessage)
                    .HasColumnType("text")
                    .HasColumnName("errorMessage")
                    .HasComment("错误信息");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(50)
                    .HasColumnName("ipAddress")
                    .HasComment("IP地址");

                entity.Property(e => e.Location)
                    .HasColumnType("text")
                    .HasColumnName("location")
                    .HasComment("IP地址转换为实际地址");

                entity.Property(e => e.LoginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("loginTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("登录时间");

                entity.Property(e => e.LoginType)
                    .HasMaxLength(50)
                    .HasColumnName("loginType")
                    .HasComment("登录类型");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(32)
                    .HasColumnName("sessionId")
                    .HasComment("会话ID");

                entity.Property(e => e.Source)
                    .HasMaxLength(20)
                    .HasColumnName("source")
                    .HasComment("登录来源（PC端，移动端等）");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态（是否成功）");

                entity.Property(e => e.SuppId)
                    .HasMaxLength(32)
                    .HasColumnName("suppId")
                    .HasComment("供应商ID");

                entity.Property(e => e.SuppName)
                    .HasMaxLength(50)
                    .HasColumnName("suppName")
                    .HasComment("供应商名称");

                entity.Property(e => e.UserAgent)
                    .HasColumnType("text")
                    .HasColumnName("userAgent")
                    .HasComment("用户设备信息");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasComment("管理员表");

                entity.HasIndex(e => e.Account, "UQ_Users_account")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UQ_Users_userName")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasMaxLength(32)
                    .HasColumnName("userId")
                    .HasComment("用户ID");

                entity.Property(e => e.Account)
                    .HasMaxLength(20)
                    .HasColumnName("account")
                    .HasComment("账号");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasComment("创建时间");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(256)
                    .HasColumnName("passwordHash")
                    .HasComment("哈希后的密码（加盐）");

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(256)
                    .HasColumnName("passwordSalt")
                    .HasComment("盐值（用于加密）");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTime")
                    .HasComment("修改时间");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("userName")
                    .HasComment("用户名称");
            });

            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.HasKey(e => e.UserPermId)
                    .HasName("PRIMARY");

                entity.ToTable("user_permissions");

                entity.HasComment("用户权限表");

                entity.Property(e => e.UserPermId)
                    .HasMaxLength(32)
                    .HasColumnName("userPermId")
                    .HasComment("用户权限ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.EffectiveTime)
                    .HasColumnType("datetime")
                    .HasColumnName("effectiveTime")
                    .HasComment("权限生效时间/长时间权限为 null");

                entity.Property(e => e.ExpirationTime)
                    .HasColumnType("datetime")
                    .HasColumnName("expirationTime")
                    .HasComment("权限失效时间/长时间权限为 null");

                entity.Property(e => e.PermId)
                    .HasMaxLength(32)
                    .HasColumnName("permId")
                    .HasComment("权限ID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(32)
                    .HasColumnName("userId")
                    .HasComment("用户ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
