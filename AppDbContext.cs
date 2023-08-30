using Microsoft.EntityFrameworkCore;
using SalaryApp.Models;

namespace SalaryApp
{
    public class AppDbContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Department> Department { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Development" },
                new Department { Id = 2, Name = "Marketing" }
            );

            modelBuilder.Entity<Manager>().HasData(
                new Manager { Id = 1, FirstName = "John", LastName = "Doe", Salary = 80000, Email = "john@example.com", DepartmentId = 1 },
                new Manager { Id = 2, FirstName = "Jane", LastName = "Smith", Salary = 75000, Email = "jane@example.com", DepartmentId = 2 }
            );

            modelBuilder.Entity<Developer>().HasData(
                new Developer { Id = 1, FirstName = "Alice", LastName = "Johnson", Salary = 90000, Email = "alice@example.com", ManagerId = 1, DepartmentId = 1 },
                new Developer { Id = 2, FirstName = "Bob", LastName = "Williams", Salary = 85000, Email = "bob@example.com", ManagerId = 1, DepartmentId = 1 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
