
using Training.Common.Hexagon.Core;

namespace Training.Common.Hexagon.API;

public interface IAwaitableResultPresenter<TUseCase, TResult>
    where TUseCase : IUseCase
{
    Type UseCaseType => typeof(TUseCase);
    Task<TResult> GetResultAsync();
}
