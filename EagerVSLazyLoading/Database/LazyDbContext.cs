using EagerVSLazyLoading.Helper;
using EagerVSLazyLoading.Model;
using Microsoft.EntityFrameworkCore;

namespace EagerVSLazyLoading.Database
{
    internal class LazyDbContext : DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseMySql(Constant.ConnStr, ServerVersion.AutoDetect(Constant.ConnStr));
        }

        internal DbSet<Department> Departments { get; set; }
        internal DbSet<User> Users { get; set; }
    }
}
