
using BaitapcuatuiMVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BaitapcuatuiMVC.Controllers
{
    //Bat buoc bat ki trang nao muon vao duoc phai dang nhap
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];//ep sang kieu UserLogin
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { Controller = "Login", action = "Index"}));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}