#pragma warning disable CS8618

using System;

namespace Training.Common.Configuration;

public class MySqlDbConfiguration
{
    public string ConnectionString { get; set; }
    public string ApiVersion { get; set; }
    public string DefaultDatabase { get; set; }
    public TimeSpan? CommandTimeout { get; set; }
    public bool EnableAutomaticMigration { get; set; }
}
