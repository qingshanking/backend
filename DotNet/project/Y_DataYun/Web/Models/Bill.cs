using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    /// <summary>
    /// 账单表
    /// 2019年1月11日
    /// </summary>
    public class Bill
    {
        /// <summary>
        /// 账单主键GUID
        /// </summary>
        [Key]
        public string GUID { get; set; }
        /// <summary>
        /// 金额  精确到分
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 支付方式（支付方式外键关联）
        /// </summary>
        public string Paytype { get; set; }
        /// <summary>
        /// 支出类型 与支出类型表挂钩
        /// </summary>
        public string SpendingType { get; set; }
        /// <summary>
        /// 支出内容 
        /// </summary>
        public string PayContent { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}