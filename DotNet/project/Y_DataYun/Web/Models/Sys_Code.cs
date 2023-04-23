using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    /// <summary>
    /// 系统字典表
    /// 2019年1月11日
    /// </summary>
    public class Sys_Code
    {
        /// <summary>
        /// 主键GUID
        /// </summary>
        [Key]
        [StringLength(128)]
        public string GUID { get; set; }
        /// <summary>
        /// 父键GUID
        /// </summary>
        [StringLength(128)]
        public string Parent { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [StringLength(100)]
        public string Content { get; set; }
        /// <summary>
        /// 级别
        /// </summary>       
        public int Level { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(500)]
        public string Remark { get; set; }
    }
}