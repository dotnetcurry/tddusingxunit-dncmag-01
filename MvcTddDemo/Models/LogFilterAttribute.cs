using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace MvcTddDemo.Models
{

    public class LogFilterAttribute : ActionFilterAttribute
    {
        public ILoggerService LoggerService { get; set; }
        public override void OnActionExecuting(
            ActionExecutingContext filterContext)
        {
            var queryString = filterContext.RequestContext
                    .HttpContext.Request.QueryString;
            string value = queryString["log"];
            switch (value)
            {
                case "true":
                case "yes":
                case "1":
                    LoggerService.Log("Some message to log");
                    break;
                default:
                    break;
            }
        }
    }
}




