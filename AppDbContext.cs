using Microsoft.EntityFrameworkCore;
using SalaryApplication.Models;

namespace SalaryApplication
{
    public class AppDbContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Department> Departments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Department A" },
                new Department { Id = 2, Name = "Department B" }
            );

            modelBuilder.Entity<Manager>().HasData(
                new Manager { Id = 1, FirstName = "John", LastName = "Doe", Salary = 80000, DepartmentId = 1, Email = "john@example.com" },
                new Manager { Id = 2, FirstName = "Jane", LastName = "Smith", Salary = 90000, DepartmentId = 2, Email = "jane@example.com" }
            );


            modelBuilder.Entity<Developer>().HasData(
                new Developer { Id = 1, FirstName = "Tom", LastName = "Smith", Salary = 60000, Email = "tom@example.com", ManagerId = 1, DepartmentId = 1 },
                new Developer { Id = 2, FirstName = "Bob", LastName = "Johnson", Salary = 75000, Email = "bob@example.com", ManagerId = 2, DepartmentId = 2 },
                new Developer { Id = 3, FirstName = "Sam", LastName = "Brown", Salary = 90000, Email = "sam@example.com", ManagerId = 1, DepartmentId = 1 }
            );
            // Call the base method to complete the configuration
            base.OnModelCreating(modelBuilder);

        }
    }
}
