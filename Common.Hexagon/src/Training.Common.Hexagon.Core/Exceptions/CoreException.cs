namespace Training.Common.Hexagon.Core.Exceptions;

/// <summary>
/// Represents errors that occur during application execution in core module.
/// </summary>
[Serializable]
public abstract class CoreException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CoreException"/> class.
    /// </summary>
    public CoreException()
        : base() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CoreException"/> class.
    /// </summary>
    /// <param name="message"> The message that describes the error. </param>
    public CoreException(string message)
        : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CoreException"/> class.
    /// </summary>
    /// <param name="message"> The error message that explains the reason for the exception. </param>
    /// <param name="inner"> The exception that is the cause of the current exception. </param>
    public CoreException(string message, Exception inner)
        : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CoreException"/> class with serialized data.
    /// </summary>
    /// <param name="info">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
    protected CoreException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
}
