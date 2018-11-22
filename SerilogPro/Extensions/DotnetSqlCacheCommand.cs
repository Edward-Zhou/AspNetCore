using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.SqlServer;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogPro.Extensions
{
    public static class DotnetSqlCacheCommand
    {
        public static IServiceCollection ConfigureSqlCache(this IServiceCollection services)
        {
            var options = services.BuildServiceProvider().GetRequiredService<IOptions<SqlServerCacheOptions>>();
            int result = CreateTableAndIndexes(options.Value);
            return services;
        }
        public static IServiceCollection ConfigureSqlCacheFromCommand(this IServiceCollection services)
        {
            var options = services.BuildServiceProvider().GetRequiredService<IOptions<SqlServerCacheOptions>>();

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c dotnet sql-cache create \"{options.Value.ConnectionString}\" { options.Value.SchemaName } { options.Value.TableName }",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    WindowStyle = ProcessWindowStyle.Normal,
                    RedirectStandardInput = true,
                    RedirectStandardError = true
                }
            };
            process.Start();
            string input = process.StandardError.ReadToEnd();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return services;
        }
        private static int CreateTableAndIndexes(SqlServerCacheOptions options)
        {
            using (var connection = new SqlConnection(options.ConnectionString))
            {
                connection.Open();

                var sqlQueries = new SqlQueries(options.SchemaName, options.TableName);
                var command = new SqlCommand(sqlQueries.TableInfo, connection);

                using (var reader = command.ExecuteReader(CommandBehavior.SingleRow))
                {
                    if (reader.Read())
                    {
                        return 1;
                    }
                }
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        command = new SqlCommand(sqlQueries.CreateTable, connection, transaction);

                        command.ExecuteNonQuery();

                        command = new SqlCommand(
                            sqlQueries.CreateNonClusteredIndexOnExpirationTime,
                            connection,
                            transaction);

                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 1;
                    }
                }
            }
            return 0;
        }
    }
}
