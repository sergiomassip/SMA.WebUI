using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using SMA.WebUI.Exceptions;
using SMA.WebUI.Filters;

namespace SMA.WebUI.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private Stopwatch _timer;

       
        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            ViewBag.Cities = new string[] { "New York", "London", "Paris" };
            string message = "This is an HTML element: <input>";
            return View((object)message);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HandleError( View = "DetailedError")]
        [HandleError( View = "NotFound", ExceptionType = typeof(HttpException))]
        [HandleError( View = "~/Views/Shared/ConfigurationError.cshtml", ExceptionType = typeof(ConfigurationInitializationException))]
        public ActionResult Error()
        {

            //throw new ConfigurationInitializationException();
            //throw new HttpException();
            //throw new HttpException(404, "Route Not Found");
            throw new Exception("Some unknown error encountered!");
            return View();
        }

        [ProfileAll]
        public string FilterTest()
        {
            return "This is the FilterTest action";
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _timer = Stopwatch.StartNew();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _timer.Stop();
            filterContext.HttpContext.Response.Write(
                string.Format("<div>Hey you Total elapsed time: {0}</div>",
                    _timer.Elapsed.TotalSeconds));
        } 

    }
}