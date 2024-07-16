using System.Dynamic;
using Training.Common.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Training.Common.Hexagon.API;

public static class ActionResultFactory
{
    public static IActionResult Ok200() => new OkResult();
    public static IActionResult Ok200(object result) => new OkObjectResult(result);

    public static IActionResult Created201() => new StatusCodeResult(201);
    public static IActionResult Created201(object result) => new ObjectResult(result) { StatusCode = 201 };
    public static IActionResult Created201(object? routeValues, object? value) => new CreatedAtRouteResult(routeValues, value);
    public static IActionResult Created201(string? routeName, object? routeValues, object? value) => new CreatedAtRouteResult(routeName, routeValues, value) { StatusCode = 201 };

    public static IActionResult BadRequest400() => new BadRequestResult();
    public static IActionResult BadRequest400(string message) => new BadRequestObjectResult(message);
    public static IActionResult BadRequest400(object result) => new BadRequestObjectResult(result);

    public static IActionResult NotFound404(string message, object? input = null)
    {
        dynamic @object = new ExpandoObject();
        @object.Message = message;
        input?.Apply(i => @object.Input = i);

        return new NotFoundObjectResult(@object);
    }
    public static IActionResult Conflicts409(string message, object? input = null)
    {
        dynamic @object = new ExpandoObject();
        @object.Message = message;
        input?.Apply(i => @object.Input = i);

        return new ConflictObjectResult(@object);
    }
}
