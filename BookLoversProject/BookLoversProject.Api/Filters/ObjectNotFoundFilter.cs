using BookLoversProject.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

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
