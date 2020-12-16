using System.Web.Mvc;
using SMA.WebUI.Filters;

namespace SMA.WebUI.Controllers
{
    [SimpleMessage(Message = "A")]
    public class CustomerController : Controller
    {
        // GET: Customer
        [SimpleMessage(Message = "A", Order = 1)]
        [SimpleMessage(Message = "B", Order = 2)]
        public string Index()
        {
            return "This is the Customer controller";
        }

        [CustomOverrideActionFilters]
        [SimpleMessage(Message = "B")]
        public string OtherAction()
        {
            return "This is the Other Action in the Customer controller";
        }
    }
}