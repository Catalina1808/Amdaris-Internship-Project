using BookLoversProject.Application.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BookLoversProject.Presentation.Filters
{
    public class ObjectNotFoundFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ObjectNotFoundException)
            {
                context.Result = new NotFoundObjectResult(context.Exception.Message);
            }
        }
    }
}
