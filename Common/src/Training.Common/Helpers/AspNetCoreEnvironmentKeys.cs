namespace Microsoft.Extensions.Configuration;

public static class AspNetCoreEnvironmentKeys
{
    public const string Prefix = "ASPNETCORE";
    public const string ApplicationName = $"{Prefix}_APPLICATIONNAME";
    public const string EnvironmentName = $"{Prefix}_ENVIRONMENT";
    public const string ContentRoot = $"{Prefix}_CONTENTROOT";
}
