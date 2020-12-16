using System;
using System.Runtime.Serialization;

namespace SMA.WebUI.Exceptions
{

    public class ConfigurationInitializationException : Exception
    {
        public ConfigurationInitializationException()
        {

        }

        public ConfigurationInitializationException(string message)
            : base(message)
        {

        }
        public ConfigurationInitializationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
        protected ConfigurationInitializationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}