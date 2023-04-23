using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    /// <summary>
    /// 卡包表
    /// 2019年1月11日
    /// </summary>
    public class CardBag
    {
        /// <summary>
        /// 主键GUID
        /// </summary>
        [Key]
        public string Guid { get; set; }
        /// <summary>
        /// 卡编号（银行卡号，支付宝 微信账号）
        /// </summary>
        [Required]
        [StringLength(200)]
        public string CardId { get; set; }
        /// <summary>
        /// 余额
        /// </summary>        
        public decimal Money { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Userguid { get; set; }
        /// <summary>
        /// 卡包类型 字典表 对应
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CardBagType { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200)]
        public string Remark { get; set; }
    }
}