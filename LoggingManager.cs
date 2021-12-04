using System;
namespace Logging
{
    public class LoggingManager
    {
        public ILogger logger
        {
            get;
            set;
        }

        public void Log(LogLevel loglevel, LogCategory logcategory, string operation, string message)
        {
            logger.Log(loglevel, logcategory, operation, message);
        }

        public LoggingManager()
        {
            this.logger = new MemoryLogger();
        }
    }
}
