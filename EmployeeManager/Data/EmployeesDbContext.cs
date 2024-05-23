using EmployeeManager.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EmployeeManager.Data
{
    internal class EmployeesDbContext : DbContext
    {
        public EmployeesDbContext() { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=EmployeesDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
