using Training.Common.Hexagon.Core;
using Serilog;

namespace Training.Common.Hexagon.API;

public abstract class AwaitableResultPresenterBase<TUseCase, TResult> : IAwaitableResultPresenter<TUseCase, TResult>
    where TUseCase : IUseCase
{
    private readonly TaskCompletionSource<TResult> resultSource = new();

    protected AwaitableResultPresenterBase(ILogger logger) => this.Logger = logger;

    public Type UseCaseType { get; } = typeof(TUseCase);
    protected ILogger Logger { get; }

    public Task<TResult> GetResultAsync() => this.resultSource.Task;

    protected void SetResult(TResult result) => this.resultSource.SetResult(result);

    protected void SetException(IEnumerable<Exception> exceptions) => this.resultSource.SetException(exceptions);

    protected void SetException(Exception exception) => this.resultSource.SetException(exception);
}