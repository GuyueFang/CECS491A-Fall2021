using System;
namespace Logging
{
    public struct LogEntry
    {
        internal ulong id { get; }
        public LogLevel loglevel { get; }
        public LogCategory logcategory { get; }
        public string operation { get; }
        public string message { get; }
        public DateTime timeStamp { get; }
        internal LogEntry(ulong id, LogLevel loglevel, LogCategory logcategory, string operation, string message, DateTime timeStamp)
        {
            this.id = id;
            this.loglevel = loglevel;
            this.logcategory = logcategory;
            this.operation = operation;
            this.message = message;
            this.timeStamp = timeStamp;
        
        }

        internal LogEntry(string stream)
        {
            string[] elements = stream.Trim().Split(',');
            id = ulong.Parse(elements[0]);
            loglevel = System.Enum.Parse<LogLevel>(elements[1]);
            logcategory = System.Enum.Parse<LogCategory>(elements[2]);
            operation = elements[3];
            message = elements[4];
            timeStamp = DateTime.Parse(elements[5]);
        }

        public override string ToString()
        {
            return $"{id},{loglevel},{logcategory},{operation},{message},{timeStamp}\n";
        }
    }
}
