#pragma warning disable CS8618

using System;
using System.Collections.Generic;

namespace Training.Common.Configuration;

public class OpenApiClientConfiguration
{
    public string? BasePath { get; set; }
    public string? DateTimeFormat { get; set; }
    public IDictionary<string, string> DefaultHeaders { get; set; } = new Dictionary<string, string>();
    public TimeSpan Timeout { get; set; } = TimeSpan.FromMilliseconds(100000);
    public string? UserAgent { get; set; }
}

