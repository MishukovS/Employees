using Employees.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.DataAcсess.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>(ConfigureEmployee);
        }

        private void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.SalarySum);

            builder.Property(oi => oi.Name)
              .IsRequired(true)
              .HasMaxLength(200);

            builder.Property(oi => oi.SalarySum)
               .IsRequired(true)
               .HasColumnType("decimal(18,2)");
        }
    }
}
