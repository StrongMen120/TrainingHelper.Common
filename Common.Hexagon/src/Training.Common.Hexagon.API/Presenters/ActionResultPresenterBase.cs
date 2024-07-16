using Microsoft.AspNetCore.Mvc;
using Training.Common.Hexagon.Core;
using Serilog;

namespace Training.Common.Hexagon.API;

public abstract class ActionResultPresenterBase<TUseCase> : AwaitableResultPresenterBase<TUseCase, IActionResult>, IActionResultPresenter<TUseCase>
    where TUseCase : IUseCase
{
    protected ActionResultPresenterBase(ILogger logger, IApiMapper mapper)
        : base(logger) => this.Mapper = mapper;

    protected IApiMapper Mapper { get; }
}
