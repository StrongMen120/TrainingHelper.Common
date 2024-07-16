using System;

namespace Microsoft.Extensions.Configuration;

public static partial class ConfigurationHelper
{
    private static string GetDefaultSectionNameFrom(Type type) => type.Name;

    public static IConfiguration ExpectDefined(this IConfiguration configuration, string configKey)
    {
        if (!configuration.IsDefined(configKey)) throw new ConfigurationMissingException(configKey);

        return configuration;
    }

    public static IConfiguration ExpectConnectionStringDefined(this IConfiguration configuration, string connectionStringName)
    {
        if (!configuration.IsConnectionStringDefined(connectionStringName)) throw new ConfigurationMissingException(connectionStringName);

        return configuration;
    }

    public static bool IsConnectionStringDefined(this IConfiguration configuration, string connectionStringName)
        => !string.IsNullOrEmpty(configuration.GetConnectionString(connectionStringName));

    public static bool IsDefined(this IConfiguration configuration, string configKey)
        => !string.IsNullOrEmpty(configuration[configKey]);

    public static T BindConfig<T>(this IConfiguration configuration, T config, string? sectionName = null)
    {
        var section = configuration.GetSection(sectionName ?? typeof(T).Name);

        if (section != null)
        {
            section.Bind(config);
        }

        return config;
    }
}

