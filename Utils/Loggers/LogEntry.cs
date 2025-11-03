using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesReader.Utils.Loggers;


public class LogEntry
{
    private readonly DateTime _timestamp;
    private readonly string _message;
    private readonly string _stackTrace;

    public LogEntry(string message, string stackTrace)
    {
        _timestamp = DateTime.Now;
        _message = message;
        _stackTrace = stackTrace;
    }

    public override string ToString()
    {
        return $"[{_timestamp:MM/dd/yyyy HH:mm:ss}]" +
            $"Message: {_message}, StackTrace: {_stackTrace}";
    }
}
