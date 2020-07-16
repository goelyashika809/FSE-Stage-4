using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace handson3.Filters
{
    public class CustomAuthFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            /*if (context.HttpContext.Request.Headers["Authentication"].ToBoolean()==true)

                if (context.HttpContext.Request.Headers.TryGetValue("Authentication", out headervalue))*/
            if (context.HttpContext.Request.Query.ContainsKey("Authorization") && context.HttpContext.Request.Query["Authorization"] == "true")
            {

                context.Result = new UnauthorizedResult();
            }
            else
            {

                base.OnActionExecuting(context);
            }

            base.OnActionExecuting(context);
        }
    }
}