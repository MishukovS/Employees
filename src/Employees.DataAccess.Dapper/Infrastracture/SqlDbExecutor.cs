using Dapper;
using Employees.Core.Interfaces.DatаAccess;
using Employees.Core.Interfaces.Infrastracture;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.DataAccess.Dapper.Infrastracture
{
    public class SqlDbExecutor : ISqlDbExecutor
    {
        private readonly int? _defaultTimeout = 10;
        private readonly int _timeForLoggingMs = 500;
        private readonly string _connectionString;
        private readonly ILogger _logger;

        public SqlDbExecutor(ISettings settings, ILogger<SqlDbExecutor> logger)
        {
            _connectionString = settings.GetConnectionString();
            _logger = logger;
        }

        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object queryParams = null)
        {
            using (var cnn = new SqlConnection(_connectionString))
            {
                var watch = Stopwatch.StartNew();

                await cnn.OpenAsync();
                var result = await cnn.QueryAsync<T>(
                    sql: sql,
                    param: queryParams,
                    commandTimeout: _defaultTimeout
                    );

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                if (elapsedMs > _timeForLoggingMs)
                {
                    _logger.LogInformation($"Long sql query : {sql}");
                }

                return result.ToArray();

            }
        }


        public async Task<T> FirstOrDefaultAsync<T>(string sql, object queryParams = null)
        {
            using (var cnn = new SqlConnection(_connectionString))
            {
                var watch = Stopwatch.StartNew();
                await cnn.OpenAsync();

                var result = await cnn.QueryFirstOrDefaultAsync<T>(
                    sql: sql,
                    param: queryParams,
                    commandTimeout: _defaultTimeout
                );

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                if (elapsedMs > _timeForLoggingMs)
                {
                    _logger.LogInformation($"Long sql query : {sql}");
                }

                return result;
            }
        }

    }
}

