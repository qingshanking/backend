namespace Web.Models
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class DBModel : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“DBModel”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Web.Models.DBModel”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“DBModel”
        //连接字符串。
        public DBModel()
            : base("name=DBModel")
        {
            //自动创建表，如果Entity有改到就更新到表结构
            Database.SetInitializer<DBModel>(new MigrateDatabaseToLatestVersion<DBModel, ReportingDbMigrationsConfiguration>());
        }

        #region 模型表
        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        /// <summary>
        /// 系统字典表
        /// </summary>
        public virtual DbSet<Sys_Code> Sys_Codes { get; set; }
        /// <summary>
        /// 卡包表
        /// </summary>
        public DbSet<CardBag> CardBags { get; set; }
        /// <summary>
        /// 定义实体 账单表
        /// </summary>
        public DbSet<Bill> Bills { get; set; }

        #endregion


        /// <summary>
        /// 重写 OnModelCreating方法
        /// DomainMapping  所在的程序集一定要写对，因为目前在当前项目所以是采用的当前正在运行的程序集 如果你的mapping在单独的项目中 记得要加载对应的assembly
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //表名为类名，不是带s的表名  //移除复数表名的契约
            //modelBuilder.Entity<Sys_Code>().ToTable("Sys_Code");//模型生成器 生成Sys_Code 类的model 到表Sys_Code
            //modelBuilder.Entity<Bill>().ToTable("Bill");
            //modelBuilder.Entity<CardBag>().ToTable("CardBag");
            base.OnModelCreating(modelBuilder);//重写完毕模型生成规则
        }
        internal sealed class ReportingDbMigrationsConfiguration : DbMigrationsConfiguration<DBModel>
        {
            public ReportingDbMigrationsConfiguration()
            {
                AutomaticMigrationsEnabled = true;//任何Model Class的修改將會直接更新DB
                AutomaticMigrationDataLossAllowed = true;
            }
        }

    }
    

}