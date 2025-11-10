namespace GamesReader.Logging;


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
