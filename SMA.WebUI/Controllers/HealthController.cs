using System;
using System.Diagnostics;
using System.Web.Mvc;
using SMA.WebUI.Filters;

namespace SMA.WebUI.Controllers
{
    public class HealthController : Controller
    {
        // GET: Health
        [CustomErrorHandler]
        public ActionResult Index()
        {
            throw  new Exception();
            return View();
        }

        public string Index2()
        {
            throw new Exception();
            return "Hola";
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Trace.TraceError(filterContext.Exception.Message);
            Response.StatusCode = 400;
            //var model = new HandleErrorInfo(filterContext.Exception, "Health", "Index");
            //Redirect or return a view, but not both.
            //filterContext.Result = RedirectToAction("Index", "ErrorHandler");
            // OR 
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}