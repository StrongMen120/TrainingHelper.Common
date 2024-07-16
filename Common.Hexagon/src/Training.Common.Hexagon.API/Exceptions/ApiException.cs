namespace Training.Common.Hexagon.API.Exceptions;

/// <summary>
/// General exception.
/// </summary>
[Serializable]
public class ApiException : Exception
{
    /// <inheritdoc/>
    public ApiException()
        : base() { }

    /// <inheritdoc/>
    public ApiException(string message)
        : base(message) { }

    /// <inheritdoc/>
    public ApiException(string message, Exception inner)
        : base(message, inner) { }

    /// <inheritdoc/>
    protected ApiException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
}
