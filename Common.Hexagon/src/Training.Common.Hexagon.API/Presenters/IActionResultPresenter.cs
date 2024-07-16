using Training.Common.Hexagon.Core;
using Microsoft.AspNetCore.Mvc;

namespace Training.Common.Hexagon.API;

public interface IActionResultPresenter<TUseCase> : IAwaitableResultPresenter<TUseCase, IActionResult>
    where TUseCase : IUseCase
{ }
