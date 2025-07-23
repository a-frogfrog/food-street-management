using System;
using System.Collections.Generic;

namespace FSM.Infrastructure.EFCore.MySql.Models
{
    /// <summary>
    /// 商品主表
    /// </summary>
    public partial class Product
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public string ProductId { get; set; } = null!;
        /// <summary>
        /// 关联的供应商ID
        /// </summary>
        public string SupplierId { get; set; } = null!;
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; } = null!;
        /// <summary>
        /// 商品类别
        /// </summary>
        public string ProductCategory { get; set; } = null!;
        /// <summary>
        /// 单位/规格（kg/件/箱）
        /// </summary>
        public string Unit { get; set; } = null!;
        /// <summary>
        /// 单价
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 商品状态
        /// </summary>
        public sbyte Status { get; set; }
        /// <summary>
        /// 创建时间（自动生成）
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string? Description { get; set; }
    }
}
