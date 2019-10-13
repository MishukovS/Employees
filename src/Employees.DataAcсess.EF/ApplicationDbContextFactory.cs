using Employees.Core.Infrastrature;
using Employees.Core.Interfaces.Infrastracture;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Employees.DataAcсess.EF
{
    /// <summary>
    /// Этот класс требуется для формирования миграций
    /// без него не создается DbContext во время миграции
    /// </summary>
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private readonly ISettings _settings;

        public ApplicationDbContextFactory()
        {
            _settings = new Settings();
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var connectionString = _settings.GetConnectionString();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(
                        connectionString,
                        optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name));

            return new ApplicationDbContext(builder.Options);
        }
    }
}
