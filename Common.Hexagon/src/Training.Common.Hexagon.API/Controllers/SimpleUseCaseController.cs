using Training.Common.Hexagon.Core;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Training.Common.Hexagon.API.Controllers;

public abstract class SimpleUseCaseController<TUseCase, TPresenter> : ControllerBase
where TUseCase : IUseCase
where TPresenter : ActionResultPresenterBase<TUseCase>
{
    protected SimpleUseCaseController(ILogger logger, TUseCase useCase, TPresenter presenter)
    {
        this.Logger = logger.ForContext(this.GetType());
        this.UseCase = useCase;
        this.Presenter = presenter;
    }

    protected ILogger Logger { get; }
    protected TUseCase UseCase { get; }
    protected TPresenter Presenter { get; }
}
