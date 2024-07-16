namespace Training.Common.Hexagon.Core;

/// <summary>
/// Default empty input port.
/// </summary>
public sealed class NullInputPort : IInputPort
{
    private static readonly Lazy<NullInputPort> InstanceSingleton = new(() => new NullInputPort());

    private NullInputPort()
    { }

    /// <summary>
    /// Gets singleton instance of <see>NullInputPort</see>.
    /// </summary>
    /// <value>
    /// Singleton instance of <see>NullInputPort</see>.
    /// </value>
    public static NullInputPort Instance => InstanceSingleton.Value;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NullInputPort && obj == this;

    /// <inheritdoc/>
    public override int GetHashCode() => 7919; // Just prime

    /// <inheritdoc/>
    public override string ToString() => nameof(NullInputPort);
}