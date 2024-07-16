using System;

namespace Microsoft.Extensions.Configuration;

public static partial class ConfigurationHelper
{
    public static T GetSectionOrDefault<T>(this IConfiguration configuration)
        where T : class, new()
        => GetSectionOrDefault<T>(configuration, GetDefaultSectionNameFrom(typeof(T))) ?? new T();

    public static T GetSectionOrDefault<T>(this IConfiguration configuration, string sectionName)
        where T : class, new()
        => GetSection<T>(configuration, sectionName) ?? new T();

    public static T GetSectionOrDefault<T>(this IConfiguration configuration, T defaultValue)
        where T : class
        => GetSection<T>(configuration, GetDefaultSectionNameFrom(typeof(T))) ?? defaultValue;

    public static T GetSectionOrDefault<T>(this IConfiguration configuration, string sectionName, T defaultValue)
        where T : class
        => GetSection<T>(configuration, sectionName) ?? defaultValue;

    public static T GetSectionOrDefault<T>(this IConfiguration configuration, Func<string, T> defaultValueFactory)
        where T : class
        => GetSection<T>(configuration, GetDefaultSectionNameFrom(typeof(T))) ?? defaultValueFactory(GetDefaultSectionNameFrom(typeof(T)));

    public static T GetSectionOrDefault<T>(this IConfiguration configuration, string sectionName, Func<string, T> defaultValueFactory)
        where T : class
        => GetSection<T>(configuration, sectionName) ?? defaultValueFactory(sectionName);
}
