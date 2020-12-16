using System.Web.Mvc;

namespace SMA.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(int statusCode = 0, string errorDescription = "")
        {
            Response.StatusCode = statusCode;

            switch (statusCode)
            {
                case int c when (c >= 500 && c < 600 ):
                    ViewBag.Title = "Server Error";
                   

                    ViewBag.Description = "Oops! Something is broken :( ...";
                    break;

                case int c when (c >= 400 && c < 500):
                    ViewBag.Title = "Page Not Found";
                    ViewBag.Description = "Sorry, we can't find the page you were looking for";


                   
                    //return RedirectToAction("NotFound", new { statusCode });
                    break;
                default:
                    ViewBag.Title = "Oops! Something is broken";
                    ViewBag.Description = "Oops! Something is broken :( ...";
                    break;
            }

            #if DEBUG
                        ViewBag.Description = errorDescription;
            #endif

            return View();
        }

        // GET: Error
        public ActionResult NotFound(int statusCode)
        { 
            ViewBag.Title = "Página no encontrada";
            ViewBag.Description = "La URL que está intentando ingresar no existe";
            Response.StatusCode = statusCode;

            return View();
       }

       public ActionResult AccessDenied() {
           
           Response.StatusCode = 403;
            return View();
       }

       public ActionResult ServerError() {
           Response.StatusCode = 500;
           return View();
       }
        
    }
}