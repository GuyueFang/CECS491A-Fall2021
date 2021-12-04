using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logging
{
    public interface ILogger
    {
        public Task Log(LogLevel loglevel, LogCategory logcategory, string operation, string message);
        public Task<IList<LogEntry>> GetAllLogs();
    }
}
