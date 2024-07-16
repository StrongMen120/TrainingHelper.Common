using System;

namespace Microsoft.Extensions.Configuration;

public static partial class ConfigurationHelper
{
    public static T GetRequiredSection<T>(this IConfiguration configuration, string sectionName)
        where T : class
    {
        try
        {
            return configuration.GetRequiredSection(sectionName).Get<T>();
        }
        catch (InvalidOperationException e)
        {
            throw new ConfigurationMissingException(sectionName, e);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static T GetRequiredSection<T>(this IConfiguration configuration)
        where T : class
        => GetRequiredSection<T>(configuration, typeof(T).Name);
}
