#pragma warning disable CS8618

using System;

namespace Training.Common.Configuration;

public class PostgresDbConfiguration
{
    public string ConnectionString { get; set; }
    public string ApiVersion { get; set; }
    public string DefaultDatabase { get; set; }
    public TimeSpan? CommandTimeout { get; set; }
    public bool EnableAutomaticMigration { get; set; }

    public Version PostgresApiVersion => Version.TryParse(this.ApiVersion, out var temp) ? temp : new Version(12, 0);
}

