using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PrintManagementApp.Filters
{

    
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
        public class SessionExpireFilterAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                HttpContext ctx = HttpContext.Current;

                // If the browser session or authentication session has expired...
                if (ctx.Session["AccountName"] == null )
                {
                    
                        // For round-trip posts, we're forcing a redirect to Home/TimeoutRedirect/, which
                        // simply displays a temporary 5 second notification that they have timed out, and
                        // will, in turn, redirect to the logon page.
                        filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary {
                        { "Controller", "Account" },
                        { "Action", "Login" }
                        });
                    
                }

                base.OnActionExecuting(filterContext);
            }
        }
    
    }
    