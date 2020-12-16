using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SMA.WebUI.Helpers
{
    public class Log4netTraceListener : TraceListener
    {
        public Log4netTraceListener() {

        }
        
        /// <summary>
        /// Gets or sets the trace source collection.
        /// </summary>
        private List<TraceSource> TraceSourceCollection { get; set; }

        /// <summary>
        /// Gets or sets the active trace type.
        /// </summary>
        public TraceLevel ActiveTraceLevel { get; set; }

        public override void Write(string message)
        {
            throw new NotImplementedException();
        }

        public override void WriteLine(string message)
        {
            throw new NotImplementedException();
        }
    }
}