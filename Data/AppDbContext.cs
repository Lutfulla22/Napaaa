using Microsoft.EntityFrameworkCore;
using Napa.Models;

namespace Napa.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Username = "Admin", Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product()
                        {
                            Id = 1,
                            Title = "HDD 1Tb",
                            Quantiy = 55,
                            Price = 74.09
                        },
                        new Product()
                        {
                            Id = 2,
                            Title = "HDD SSD 512GB",
                            Quantiy = 102,
                            Price = 190.99,
                        },
                        new Product()
                        {
                            Id = 3,   
                            Title = "RAM DDR4 16GB",
                            Quantiy = 47,
                            Price = 80.32
                        }
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
