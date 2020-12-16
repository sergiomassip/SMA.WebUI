using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SMA.WebUI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected virtual void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Response.Clear();
            Server.ClearError();
            var httpException = exception as HttpException;
            var error = httpException?.GetHttpCode() ?? 500;
            Response.Redirect($"~/Error/?statusCode={error}&errorDescription={exception.Message}");
        }
    }
}


/* protected virtual void Application_Error(object sender, EventArgs e)
        {


            Exception exception = Server.GetLastError();
            Response.Clear();
            HttpException httpException = exception as HttpException;

            int error = httpException != null ? httpException.GetHttpCode() : 0;

            Server.ClearError();
            Response.Redirect(string.Format("~/Error/?error={0}", error, exception.Message));

          

        }

          var exception = Server.GetLastError();
          Trace.TraceError(exception.Message);

          HttpException httpException = exception as HttpException ?? new HttpException(500, "Internal Server Error", exception);
          Response.Clear();           
          var routeData = new RouteData();            
          routeData.Values.Add("controller", "Error");
          routeData.Values.Add("fromAppErrorEvent", true);
          switch (httpException.GetHttpCode()) {
              case 403:
                  routeData.Values.Add("action", "AccessDenied");
                  break;
              case 404:
                  routeData.Values.Add("action", "NotFound");
                  break;
              case 500:
                  routeData.Values.Add("action", "ServerError");
                  break;
              default:
                  routeData.Values.Add("action", "OtherHttpStatusCode");
                  routeData.Values.Add("httpStatusCode", httpException.GetHttpCode());
                  break;                
          }

          Server.ClearError();
          IController controller = new ErrorController();
          controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
          */