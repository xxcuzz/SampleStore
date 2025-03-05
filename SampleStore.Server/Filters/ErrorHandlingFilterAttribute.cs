using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SampleStore.API.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var problemDetails = new ProblemDetails
        {
            Title = "An error occurred while processing your request",
            Type = "https://httpstatuses.com/500",
            Status = StatusCodes.Status500InternalServerError,
        };

        context.Result = new ObjectResult(problemDetails);
        
        base.OnException(context);
    }
}