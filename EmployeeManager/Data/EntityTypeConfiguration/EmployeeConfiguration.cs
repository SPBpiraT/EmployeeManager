using EmployeeManager.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManager.Data.EntityTypeConfiguration
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(employee => employee.Id);
            builder.HasIndex(employee => employee.Id).IsUnique();
            builder.HasIndex(employee => employee.FirstName);
            builder.HasIndex(employee => employee.Gender);

        }
    }
}
