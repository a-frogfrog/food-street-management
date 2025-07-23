using System;
using System.Collections.Generic;

namespace FSM.Infrastructure.EFCore.MySql.Models
{
    /// <summary>
    /// 订单详情表
    /// </summary>
    public partial class OrderDetail
    {
        /// <summary>
        /// 详情ID
        /// </summary>
        public string DetailId { get; set; } = null!;
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderId { get; set; } = null!;
        /// <summary>
        /// 商品ID
        /// </summary>
        public string ProductId { get; set; } = null!;
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; } = null!;
        /// <summary>
        /// 商品图表地址
        /// </summary>
        public string? ProductImageUrl { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int PurchaseQuantity { get; set; }
        /// <summary>
        /// 小计
        /// </summary>
        public double Subtotal { get; set; }
        /// <summary>
        /// 活动ID/不是活动为null
        /// </summary>
        public string? PromotionId { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string? Specification { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
