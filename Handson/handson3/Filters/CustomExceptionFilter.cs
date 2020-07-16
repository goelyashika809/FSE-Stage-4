using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace handson3.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute, IExceptionFilter
    {
        private const bool V = true;

        public override void OnException(ExceptionContext context)
        {

            var error = context.Exception;
            string strPath = @"D:\error.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + error.Message);
                sw.WriteLine("Stack Trace: " + error.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }

            context.HttpContext.Response.StatusCode = 401;
            context.Result = new ExceptionResult(error, V);
            context.ExceptionHandled = true;
            base.OnException(context);
        }
    }
}
