using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logging
{
    public class MemoryLogger : ILogger
    {
        private static ulong nextEntryId;
        private IList<LogEntry> logs = new List<LogEntry>();
        public Task Log(LogLevel loglevel, LogCategory logcategory, string operation, string message)
        {
            LogEntry entry = new LogEntry(nextEntryId, loglevel, logcategory, operation, message, DateTime.Now);
            logs.Add(entry);
            ++nextEntryId;
            return Task.CompletedTask;
        }
        

        public Task<IList<LogEntry>> GetAllLogs()
        {
            return Task.FromResult(logs);
        }

        public MemoryLogger()
        {

        }
    }
}
