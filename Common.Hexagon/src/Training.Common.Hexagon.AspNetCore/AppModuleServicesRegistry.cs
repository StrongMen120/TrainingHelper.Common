using Microsoft.AspNetCore.Builder;
using Training.Common.Hexagon.Core.Infrastructure;
using Serilog;

namespace Training.Common.Hexagon.Infrastructure;

public abstract class AppModuleServicesRegistry : ModuleServicesRegistry
{
    private readonly LinkedList<(string Name, AppInitializer Initializer)> appInitializers = new();

    protected delegate void AppInitializer(IApplicationBuilder app, ILogger logger);

    /// <summary>
    /// Performs service initialization of all init-callbacks.
    /// </summary>
    /// <param name="app"> Application host. </param>
    /// <param name="logger"> Logger object. </param>
    public void InitServices(IApplicationBuilder app, ILogger logger)
    {
        base.InitServices(app.ApplicationServices, logger);

        foreach (var (name, initializer) in this.appInitializers)
        {
            logger.Information($"Initializing: {name}...");
            initializer?.Invoke(app, logger);
            logger.Information($"Initializing: {name}... Complete!");
        }
    }

    /// <summary>
    /// Registers service initializer to be run at app startup.
    /// </summary>
    /// <param name="name"> Name of sub module / services pack. </param>
    /// <param name="initializer"> Action that will be performed at startup. </param>
    protected void AddAppInitializer(string name, AppInitializer initializer)
    {
        this.appInitializers.AddLast((name, initializer));
    }
}
