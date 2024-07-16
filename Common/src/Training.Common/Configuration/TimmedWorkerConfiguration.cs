using System;

namespace Training.Common.Configuration;

public class TimmedWorkerConfiguration
{
    public TimeSpan Interval { get; set; } = TimeSpan.FromDays(1);
    public TimeSpan InitialDelay { get; set; } = TimeSpan.Zero;
}
