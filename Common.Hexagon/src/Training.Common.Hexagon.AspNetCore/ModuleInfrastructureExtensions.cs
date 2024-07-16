using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Training.Common.Hexagon.Infrastructure;
using Training.Common.Hexagon.Core.Infrastructure;
using Serilog;

namespace Microsoft.Extensions.DependencyInjection;

public static class ModuleInfrastructureExtensions
{
    internal static readonly ConditionalWeakTable<Type, ModuleServicesRegistry> Cache = new();

    public static IServiceCollection AddModule<T>(this IServiceCollection services, IConfiguration configuration, ILogger logger)
        where T : ModuleServicesRegistry, new()
    {
        var moduleRegistry = Cache.GetValue(typeof(T), (_) => new T());
        moduleRegistry.RegisterServices(services, configuration, logger);

        return services;
    }

    public static IServiceProvider InitModule<T>(this IServiceProvider services, Serilog.ILogger logger)
        where T : ModuleServicesRegistry, new()
    {
        var moduleRegistry = Cache.GetValue(typeof(T), (_) => new T());
        moduleRegistry.InitServices(services, logger);

        return services;
    }

    public static WebApplicationBuilder AddModule<T>(this WebApplicationBuilder builder, Serilog.ILogger? logger = null)
        where T : ModuleServicesRegistry, new()
    {
        AddModule<T>(builder.Services, builder.Configuration, logger ?? Serilog.Log.Logger);

        return builder;
    }

    public static WebApplication InitModule<T>(this WebApplication app, Serilog.ILogger? logger = null)
        where T : ModuleServicesRegistry, new()
    {
        logger ??= app.Services.GetService<Serilog.ILogger>() ?? Serilog.Log.Logger;

        var moduleRegistry = Cache.GetValue(typeof(T), (_) => new T());

        if (moduleRegistry is AppModuleServicesRegistry appModuleRegistry)
        {
            appModuleRegistry.InitServices(app, logger);
        }
        else
        {
            moduleRegistry.InitServices(app.Services, logger);
        }

        return app;
    }
}
