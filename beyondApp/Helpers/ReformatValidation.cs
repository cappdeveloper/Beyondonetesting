using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beyondApp.Helpers
{
    public class ReformatValidation : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is BadRequestObjectResult badRequestObjectResult)
            {
                if (badRequestObjectResult.Value is ValidationProblemDetails)
                {
                    context.Result = new BadRequestObjectResult(GenericBadRequest());
                    //context.Result.Value.Errors = null;
                }
            }


            base.OnResultExecuting(context);
        }

        public static ValidationProblemDetails GenericBadRequest()
        {
            var problemDetails = new ValidationProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "Bad Request",
                Status = StatusCodes.Status400BadRequest
            };
            return problemDetails;
        }
    }
}

