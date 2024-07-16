namespace Training.Common.Hexagon.Persistance.Exceptions;

/// <summary>
/// General exception.
/// </summary>
[Serializable]
public class PersistanceException : Exception
{
    /// <inheritdoc/>
    public PersistanceException()
        : base() { }

    /// <inheritdoc/>
    public PersistanceException(string message)
        : base(message) { }

    /// <inheritdoc/>
    public PersistanceException(string message, System.Exception inner)
        : base(message, inner) { }

    /// <inheritdoc/>
    protected PersistanceException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
}
