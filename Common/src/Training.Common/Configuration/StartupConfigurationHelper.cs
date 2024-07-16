using System;
using Microsoft.Extensions.Configuration;

namespace Training.Common.Configuration;

public static class StartupConfigurationHelper
{
    private static readonly Lazy<bool> IsLocalLazy = new(() =>
    {
        try
        {
            return (System.Environment.GetEnvironmentVariable(AspNetCoreEnvironmentKeys.EnvironmentName) ?? System.Environment.GetEnvironmentVariable(DotnetEnvironmentKeys.EnvironmentName)) == bool.TrueString;
        }
        catch
        {
            return false;
        }
    });

    public static bool IsLocal => IsLocalLazy.Value;

    public static IConfigurationBuilder LoadStartupConfiguration(IConfigurationBuilder builder, bool forceLocal = false)
    {
        builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        builder.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable(AspNetCoreEnvironmentKeys.EnvironmentName) ?? Environment.GetEnvironmentVariable(DotnetEnvironmentKeys.EnvironmentName)}.json", optional: true, reloadOnChange: true);

        if (IsLocal || forceLocal)
        {
            builder.AddJsonFile("appsettings.local.json", true, true);
        }

        builder.AddEnvironmentVariables();

        return builder;
    }
}
