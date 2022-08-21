
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Filters
{
    public class SessionTimeoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //HttpContext.Session.SetInt32("UserID", result);
            
            HttpContext ctx = filterContext.HttpContext;
            int? LoginedDataId = ctx.Session.GetInt32("LoginedDataId");

            if (LoginedDataId == null)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //To do : after the action executes  
            base.OnActionExecuted(context);
        }
    }
}
