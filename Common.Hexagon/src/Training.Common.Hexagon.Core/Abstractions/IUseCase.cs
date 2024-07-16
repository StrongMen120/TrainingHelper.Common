namespace Training.Common.Hexagon.Core;

/// <summary>
/// General use-case marker interface.
/// </summary>
public interface IUseCase
{
    /// <summary>
    /// General use-case definition interface.
    /// </summary>
    /// <param name="inputPort"> Input port instace. </param>
    /// <param name="outputPort"> Output port instace. </param>
    /// <returns> Task. </returns>
    Task Execute(object inputPort, object outputPort);
}

/// <summary>
/// Use-case definition interface.
/// </summary>
/// <typeparam name="TInputPort"> Input port type. </typeparam>
/// <typeparam name="TOutputPort"> Output port type. </typeparam>
public interface IUseCase<in TInputPort, TOutputPort> : IUseCase
    where TInputPort : IInputPort
    where TOutputPort : IOutputPort
{
    /// <summary>
    /// Use-case definition interface.
    /// </summary>
    /// <param name="inputPort"> Input port instace. </param>
    /// <param name="outputPort"> Output port instace. </param>
    /// <returns> Task. </returns>
    Task Execute(TInputPort inputPort, TOutputPort outputPort);

    Task IUseCase.Execute(object inputPort, object outputPort) => this.Execute((TInputPort)inputPort, (TOutputPort)outputPort);
}

/// <summary>
/// Use-case definition interface with default input.
/// </summary>
/// <typeparam name="TOutputPort"> Output port type. </typeparam>
public interface IUseCase<TOutputPort> : IUseCase<NullInputPort, TOutputPort>
    where TOutputPort : IOutputPort
{ }