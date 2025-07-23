using System;
using System.Collections.Generic;

namespace FSM.Infrastructure.EFCore.MySql.Models
{
    /// <summary>
    /// 订单表
    /// </summary>
    public partial class Order
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrederId { get; set; } = null!;
        /// <summary>
        /// 商户ID
        /// </summary>
        public string MerchantId { get; set; } = null!;
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string SupplierId { get; set; } = null!;
        /// <summary>
        /// 类别
        /// </summary>
        public int Category { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double Money { get; set; }
        /// <summary>
        /// 是否支付
        /// </summary>
        public int IsPay { get; set; }
        /// <summary>
        /// 是否发货
        /// </summary>
        public int IsSend { get; set; }
        /// <summary>
        /// 是否收货
        /// </summary>
        public int IsReceive { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public int IsComplete { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime? PayTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
