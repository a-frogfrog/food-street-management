using System;
using System.Collections.Generic;

namespace FSM.Infrastructure.EFCore.MySql.Models
{
    /// <summary>
    /// 字典表 (存储状态，类型等)
    /// </summary>
    public partial class Dictionary
    {
        /// <summary>
        /// 字典ID
        /// </summary>
        public string DictionaryId { get; set; } = null!;
        /// <summary>
        /// 字典名称
        /// </summary>
        public string DictionaryName { get; set; } = null!;
        /// <summary>
        /// 字典value
        /// </summary>
        public string DictionaryValue { get; set; } = null!;
        /// <summary>
        /// 字典名称
        /// </summary>
        public string Code { get; set; } = null!;
        /// <summary>
        /// 字典序号
        /// </summary>
        public int SerialNumber { get; set; }
        /// <summary>
        /// 父级字典ID，为子级字典特有字段
        /// </summary>
        public string? ParentId { get; set; }
        /// <summary>
        /// 层级
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 是否为节点
        /// </summary>
        public int IsNode { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; }
    }
}
