using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace SMA.WebUI.Configuration
{
    public class Configuration: IConfiguration
    {
        public string AppName { get; set; }

        public Configuration()
        {
            AppName = "SMA.WebUI";
        }
    }
}