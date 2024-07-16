using System;

namespace Microsoft.Extensions.Configuration;

public static partial class ConfigurationHelper
{
    public static T? GetSection<T>(this IConfiguration configuration)
        where T : class
        => configuration.GetSection(GetDefaultSectionNameFrom(typeof(T))).Get<T>();

    public static T? GetSection<T>(this IConfiguration configuration, string sectionName)
        where T : class
        => configuration.GetSection(sectionName).Get<T>();
}
