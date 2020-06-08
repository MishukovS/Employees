using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Employees.DataAcсess.EF
{
    /// <summary>
    /// Этот класс требуется для формирования миграций
    /// без него не создается DbContext во время миграции
    /// </summary>
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private readonly string _connectionString;
        public ApplicationDbContextFactory(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionString"];
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {        
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(
                        _connectionString,
                        optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name));

            return new ApplicationDbContext(builder.Options);
        }
    }
}
