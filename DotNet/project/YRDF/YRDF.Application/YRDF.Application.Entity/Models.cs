using System;
using System.Data.Entity;
using System.Linq;

namespace YRDF.Application.Entity
{


    public class Models : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“Models”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“YRDF.Application.Entity.Models”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“Models”
        //连接字符串。
        public Models()
            : base("name=EFCodeFirst")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        /// <summary>
        /// 系统业务_用户表
        /// </summary>
        public virtual DbSet<Sys_UserInfo> Sys_UserInfo { get; set; }

        /// <summary>
        /// 系统业务_角色表
        /// </summary>
        public virtual DbSet<Sys_Role> Sys_Role { get; set; }

        //public virtual DbSet<MyEntity> MyEntities { get; set; }
        /// <summary>
        /// 用户表
        /// </summary>
        //public virtual DbSet<RDF_Sys_UserInfo> RDF_Sys_UserInfos { get; set; }

    }





















    //using System.ComponentModel.DataAnnotations;
    //using System.ComponentModel.DataAnnotations.Schema;
    //Table 数据表名称
    //
    //[Table("table")]
    //
    //Key 主键
    //
    //[Key]
    //
    //Column 列名，列序，列类型
    //
    //[Column("col", TypeName = "Money")]
    //
    //Required 必填项
    //
    //[Required(ErrorMessage = "{0}是必填项")]
    //
    //MaxLength 最大长度
    //
    //[MaxLength(50, ErrorMessage = "字段长度不可超过50")]
    //
    //MinLength 最小长度
    //
    //[MaxLength(50, ErrorMessage = "字段长度不可超过50"), MinLength(2)]
    //
    //NotMapped不会有映射数据字段
    //
    //[NotMapped]
    //
    //Index 指定索引字段，并可设置字段名称，索引的顺序，是否具有唯一值特性
    //
    //[Index]
    //
    //DatabaseGenerated 由数据库自行管理或运算
    //
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //
    //[Timestamp][ConcurrencyCheck] 用于数据并发
}