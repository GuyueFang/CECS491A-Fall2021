using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Logging
{
    public class FileLogger : ILogger
    {
        private static ulong nextEntryId;
        private const string Filename = "logFile";
        private static string FullPath { get; } = $"{Path.GetTempPath()}/{Filename}.txt";

        public async Task Log(LogLevel loglevel, LogCategory logcategory, string operation, string message)
        {
            if (!File.Exists(FullPath))
            {
                using FileStream stream = File.Create(FullPath);
            }

            using StreamWriter writer = new StreamWriter(FullPath);
            LogEntry entry = new LogEntry(nextEntryId, loglevel, logcategory, operation, message, DateTime.Now);
            await writer.WriteAsync(entry.ToString());
            ++nextEntryId;
        }

        public async Task<IList<LogEntry>> GetAllLogs()
        {
            if (!File.Exists(FullPath))
            {
                return new List<LogEntry>();
            }
            using StreamReader reader = new StreamReader(FullPath);
            IList<LogEntry> logs = new List<LogEntry>();
            while (!reader.EndOfStream)
            {
                string data = await reader.ReadLineAsync();
                logs.Add(new LogEntry(data));
            }
            return logs;
        }
    }
}
