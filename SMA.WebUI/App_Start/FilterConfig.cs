using System.Web.Mvc;
using SMA.WebUI.Filters;

namespace SMA.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            /*
            filters.Add(new HandleErrorAttribute{
                View = "Error"
            });*/
            filters.Add(new CustomGlobalHandleError {
                View = "Error"
            });
            filters.Add(new ProfileAllAttribute());
        }
    }
}
