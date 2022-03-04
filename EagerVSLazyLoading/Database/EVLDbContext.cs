using EagerVSLazyLoading.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EagerVSLazyLoading.Database
{
    public class EVLDbContext : DbContext
    {
        private void SeedData(ModelBuilder modelBuilder)
        {
            var depts = new List<Department>();
            var users = new List<User>();

            var mathDept = new Department("Math") { Id = 1 };
            depts.Add(mathDept);
            users.Add(new User("mathUser1", mathDept.Id) { Id = 1 });
            users.Add(new User("mathUser2", mathDept.Id) { Id = 2 });

            var chemDept = new Department("Chemistry") { Id = 2 };
            depts.Add(chemDept);
            users.Add(new User("chemUser1", chemDept.Id) { Id = 3 });
            users.Add(new User("chemUser2", chemDept.Id) { Id = 4 });
            users.Add(new User("chemUser3", chemDept.Id) { Id = 5 });

            var physDept = new Department("Physical") { Id = 3 };
            depts.Add(physDept);
            users.Add(new User("physUser1", physDept.Id) { Id = 6 });
            users.Add(new User("physUser2", physDept.Id) { Id = 7 });
            users.Add(new User("physUser3", physDept.Id) { Id = 8 });
            users.Add(new User("physUser4", physDept.Id) { Id = 9 });

            modelBuilder.Entity<Department>()
                .HasData(depts);

            modelBuilder.Entity<User>()
                .HasData(users);
        }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conStr = "server=localhost;uid=root;pwd=P@ssw0rd;database=EagerVSLazy";

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseMySql(conStr, ServerVersion.AutoDetect(conStr));

        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        DbSet<Department> Departments { get; set; }
        DbSet<User> Users { get; set; }
    }
}
