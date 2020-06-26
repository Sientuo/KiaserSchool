using KiaserModel.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiaserDLL
{
    public class KiaserDbContext:DbContext
    {
        public KiaserDbContext():base("KiaserEntities")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //2.去掉 将表名设置为实体类型名称的复数版本 的约定(如 对应ClassInfo 在数据库生成 ClassInfos表)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<ClassData> ClassData { get; set; }
        public DbSet<Menu> MenuP { get; set; }
    }
}
