using System;
using System.Web.Mvc;

namespace SMA.WebUI.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SimpleMessageAttribute : FilterAttribute, IActionFilter
    {
        public string Message { get; set; }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write(
                $"<div>[Before Action: {Message}]<div>");
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write(
                $"<div>[After Action: {Message}]<div>");
        }
    }
}