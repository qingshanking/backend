using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRDF.Application.Entity
{
    /// <summary>
    /// 表名：系统角色表
    /// 数据说明：系统业务_角色表
    /// 创建时间：2020年4月25日23:45:07
    /// </summary>
    [Table("Sys_Role")]
    public class Sys_Role
    {
        /// <summary>
        /// 角色主键
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 权限说明
        /// </summary>
        public string Explain { get; set; }

        #region 通用数据
        /// <summary>
        /// 数据状态 (0正常 1审核 2删除)
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateUser { get; set; }
        /// <summary>
        /// 创建数据名称
        /// </summary>
        public string CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        public string ModifyUser { get; set; }
        /// <summary>
        /// 修改用户昵称
        /// </summary>
        public string ModifyUserName { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        public string DelUser { get; set; }
        /// <summary>
        /// 删除用户昵称 
        /// </summary>
        public string DelUserName { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DelTime { get; set; }
        #endregion
    }


    /// <summary>
    /// 表名：系统用户表
    /// 数据说明：系统业务_用户表，管理员与普通用户共用
    /// 创建时间：2020年4月25日23:45:07
    /// </summary>
    [Table("Sys_UserInfo")]
    public class Sys_UserInfo
    {
        /// <summary>
        /// 用户主键 唯一值 GUID
        /// </summary>
        [Key]
        [Column("Id", TypeName = "varchar")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Id { get; set; }

        /// <summary>
        /// 登录账号 唯一数据 不能重复
        /// </summary>
        [Column("LoginName", TypeName = "varchar")]
        [MaxLength(30, ErrorMessage = "字段长度不可超过30"), MinLength(5)]
        [Required(ErrorMessage = "{0}是必填项")]
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码 
        /// 需加密 
        /// 加密方式 MD5(md5(明文)+登录账号)
        /// </summary>
        [Column("PassWord", TypeName = "varchar")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string PassWord { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 用户头像
        /// 头像地址(对接第三方？？)
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 手机账户 
        /// 需要实名认证 可找回密码 
        /// </summary>
        [Column("Phone", TypeName = "varchar")]
        [Required(ErrorMessage = "{0}是必填项")]
        [MaxLength(11, ErrorMessage = "字段长度不可超过11")]
        public string Phone { get; set; }

        /// <summary>
        /// 用户邮箱 
        /// 需要授权验证 可找回密码
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 角色表主键
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 是否是后端用户
        /// 0 后端 1 前端普通
        /// </summary>
        public int IsSys { get; set; }

        /// <summary>
        /// 性别 
        /// 0 女 1 男
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 注册IP
        /// </summary>
        public string RegIP { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegTime { get; set; }

        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string LoginIP { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        #region 通用数据
        /// <summary>
        /// 数据状态 (0正常 1审核 2删除)
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateUser { get; set; }
        /// <summary>
        /// 创建数据名称
        /// </summary>
        public string CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        public string ModifyUser { get; set; }
        /// <summary>
        /// 修改用户昵称
        /// </summary>
        public string ModifyUserName { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        public string DelUser { get; set; }
        /// <summary>
        /// 删除用户昵称 
        /// </summary>
        public string DelUserName { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DelTime { get; set; }
        #endregion
    }
}
