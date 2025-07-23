using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FSM.Infrastructure.EFCore.SqlServer.Models
{
    public partial class FSMDBContext : DbContext
    {
        public FSMDBContext()
        {
        }

        public FSMDBContext(DbContextOptions<FSMDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ErrorLog> ErrorLogs { get; set; } = null!;
        public virtual DbSet<LoginLog> LoginLogs { get; set; } = null!;
        public virtual DbSet<OperationLog> OperationLogs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__ErrorLog__7839F64DEDB30BDF");

                entity.Property(e => e.LogId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("logId");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime");

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("errorCode");

                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("errorMessage");

                entity.Property(e => e.ErrorType)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("errorType");

                entity.Property(e => e.HttpStatusCode).HasColumnName("httpStatusCode");

                entity.Property(e => e.StackTrace)
                    .HasColumnType("text")
                    .HasColumnName("stackTrace");
            });

            modelBuilder.Entity<LoginLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__LoginLog__7839F64DC265188A");

                entity.Property(e => e.LogId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("logId")
                    .HasComment("日志ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasComment("日志创建时间");

                entity.Property(e => e.ErrorMessage)
                    .HasColumnType("text")
                    .HasColumnName("errorMessage")
                    .HasComment("失败原因（如 “密码错误”“账户锁定” 等)");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ipAddress")
                    .HasComment("登录 IP 地址");

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
                    .IsUnicode(false)
                    .HasColumnName("loginType")
                    .HasComment("登录类型 （账号密码，扫码，验证码）");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("sessionId")
                    .HasComment("会话 ID");

                entity.Property(e => e.Source)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("source")
                    .HasComment("登录来源（如 “PC 端”“移动端”“API 接口” 等）");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("登录状态");

                entity.Property(e => e.UserAgent)
                    .HasColumnType("text")
                    .HasColumnName("userAgent")
                    .HasComment("客户端信息（如浏览器类型、操作系统、设备型号等，用于分析登录设备分布）。");

                entity.Property(e => e.UserId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("userId")
                    .HasComment("登录用户ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName")
                    .HasComment("登录用户名称");
            });

            modelBuilder.Entity<OperationLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__Operatio__7839F64D53A758E6");

                entity.HasIndex(e => e.OperationTime, "idx_operationTime");

                entity.HasIndex(e => e.OperationType, "idx_operationType");

                entity.HasIndex(e => e.Status, "idx_status");

                entity.HasIndex(e => e.UserId, "idx_userId");

                entity.Property(e => e.LogId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("logId")
                    .HasComment("日志ID");

                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("action")
                    .HasComment("操作描述");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ipAddress")
                    .HasComment("IP地址");

                entity.Property(e => e.Location)
                    .HasColumnType("text")
                    .HasColumnName("location")
                    .HasComment("IP转换为实际地址");

                entity.Property(e => e.Method)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("method")
                    .HasComment("方法类型");

                entity.Property(e => e.Module)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("module")
                    .HasComment("操作模块");

                entity.Property(e => e.ModuleUrl)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("moduleUrl")
                    .HasComment("模块地址（api/auth/login）");

                entity.Property(e => e.OperationTime)
                    .HasColumnType("datetime")
                    .HasColumnName("operationTime")
                    .HasComment("操作时间");

                entity.Property(e => e.OperationType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("operationType")
                    .HasComment("操作类型");

                entity.Property(e => e.Parameters)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("parameters")
                    .HasComment("参数");

                entity.Property(e => e.Remark)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("remark")
                    .HasComment("备注");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("操作状态");

                entity.Property(e => e.UserAgent)
                    .HasColumnType("text")
                    .HasColumnName("userAgent")
                    .HasComment("客户端信息（如浏览器类型、操作系统、设备型号等）");

                entity.Property(e => e.UserId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("userId")
                    .HasComment("用户ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName")
                    .HasComment("用户名称");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName, "UQ__Users__66DCF95C402D5C49")
                    .IsUnique();

                entity.HasIndex(e => e.Account, "UQ__Users__EA162E11E67E9F75")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("userId")
                    .HasComment("用户ID");

                entity.Property(e => e.Account)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("account")
                    .HasComment("用户账号");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("createTime")
                    .HasComment("用户创建时间");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("passwordHash")
                    .HasComment("哈希后的密码");

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("passwordSalt")
                    .HasComment("密码盐值，用户密码哈希");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("用户状态");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTime")
                    .HasComment("修改用户信息时间");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName")
                    .HasComment("用户名称");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
