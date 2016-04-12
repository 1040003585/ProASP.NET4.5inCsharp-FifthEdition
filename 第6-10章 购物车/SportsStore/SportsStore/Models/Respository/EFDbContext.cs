using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//管理NuGet程序包 Entity Framework
//引入：EntityFramework.dll
//http://msdn.microsoft.com/data/ef

using System.Data.Entity;

namespace SportsStore.Models.Respository
{
    public class EFDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// 不用添加OrderLine属性,根据Entity Framework处理外键关系的方式,
        /// OrderLine对象将自动通过与其关联的Order对象进行处理.
        /// </summary>
        public DbSet<Order> Orders { get; set; }
    }
}
//去Web.config配置添加连接字符串