using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Training.Common.Hexagon.Core.Infrastructure;

public abstract class ModuleServicesRegistry
{
    private readonly LinkedList<(string Name, ServicesRegistrar Registrar)> registrars = new();
    private readonly LinkedList<(string Name, ServicesInitializer Initializer)> initializers = new();

    protected delegate void ServicesRegistrar(IServiceCollection services, IConfiguration configuration, ILogger logger);
    protected delegate void ServicesInitializer(IServiceProvider servicesProvider, ILogger logger);

    /// <summary>
    /// Applies all services registration callbacks to given IServiceCollection.
    /// </summary>
    /// <param name="services"> Collection that services are going to be registered. </param>
    /// <param name="configuration"> Configuration object. </param>
    /// <param name="logger"> Logger object. </param>
    public void RegisterServices(IServiceCollection services, IConfiguration configuration, ILogger logger)
    {
        foreach (var (name, registrar) in this.registrars)
        {
            logger.Information($"Registering: {name}...");
            registrar?.Invoke(services, configuration, logger);
            logger.Information($"Registering: {name}... Complete!");
        }
    }

    /// <summary>
    /// Performs service initialization of all init-callbacks.
    /// </summary>
    /// <param name="services"> ServicesProvider that can be used during init. </param>
    /// <param name="logger"> Logger object. </param>
    public void InitServices(IServiceProvider services, ILogger logger)
    {
        foreach (var (name, initializer) in this.initializers)
        {
            logger.Information($"Initializing: {name}...");
            initializer?.Invoke(services, logger);
            logger.Information($"Initializing: {name}... Complete!");
        }
    }

    /// <summary>
    /// Registers services used by module to be injected into IoC container.
    /// </summary>
    /// <param name="name"> Name of sub module / services pack. </param>
    /// <param name="registrar"> Registering method. </param>
    protected void AddServices(string name, ServicesRegistrar registrar)
    {
        this.registrars.AddLast((name, registrar));
    }

    /// <summary>
    /// Registers service initializer to be run nat app startup.
    /// </summary>
    /// <param name="name"> Name of sub module / services pack. </param>
    /// <param name="initializer"> Action that will be performed at startup. </param>
    protected void AddServicesInitializer(string name, ServicesInitializer initializer)
    {
        this.initializers.AddLast((name, initializer));
    }
}
