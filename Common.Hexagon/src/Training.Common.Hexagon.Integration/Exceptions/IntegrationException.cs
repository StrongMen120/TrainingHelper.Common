namespace Training.Common.Hexagon.Integration.Exceptions;

/// <summary>
/// General exception.
/// </summary>
[Serializable]
public class IntegrationException : Exception
{
    /// <inheritdoc/>
    public IntegrationException()
        : base() { }

    /// <inheritdoc/>
    public IntegrationException(string message)
        : base(message) { }

    /// <inheritdoc/>
    public IntegrationException(string message, System.Exception inner)
        : base(message, inner) { }

    /// <inheritdoc/>
    protected IntegrationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
}
