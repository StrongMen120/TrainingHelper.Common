using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Training.Common.Configuration;

namespace Training.Common.Utils;

public class DatabaseHelper
{
    public static void MigrateDatabase<TDbContext>(System.IServiceProvider services, PostgresDbConfiguration configuration)
        where TDbContext : DbContext
    {
        var logger = services.GetService<ILogger>();
        if (configuration.EnableAutomaticMigration)
        {
            logger?.LogInformation($"Migration of '{typeof(TDbContext).Name}' started.");
            MigrateDatabase<TDbContext>(services);
            logger?.LogInformation($"Migration of '{typeof(TDbContext).Name}' completed.");
        }
        else
        {
            logger?.LogInformation($"Migration of '{typeof(TDbContext).Name}' disabled (EnableAutomaticMigration is '{configuration.EnableAutomaticMigration}').");
        }
    }

    public static void MigrateDatabase<TContext>(System.IServiceProvider services)
        where TContext : DbContext
    {
        using (var scope = services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<TContext>();
            context.Database.Migrate();
        }
    }
}