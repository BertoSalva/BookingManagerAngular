using gateway.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace gateway.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        Console.WriteLine(context.Exception);
        var error = new ErrorModel(
            500,
            context.Exception.Message,
            context.Exception.StackTrace?.ToString()
        );

        context.Result = new JsonResult(error);
    }
}
