using GamesReader.UI;
using System.IO;


namespace GamesReader.Utils.Loggers;

public class FileSystemLogger : ILogger
{
    private readonly string? _logFolderName;
    private readonly string? _logFileName;
    private readonly string? _logFilePath;

    private static FileSystemLogger? _instance;
    private readonly IUI? _ui;

    private FileSystemLogger(IUI ui, string folderName, string fileName)
    {
        _logFolderName = folderName;
        _logFileName = fileName;
        _logFilePath = Path.Combine(_logFolderName, _logFileName);
        _ui = ui;
    }

    public static void CreateInstance(IUI ui, string folderName = "Logs", string fileName = "error_log.txt")
    {
        _instance ??= new FileSystemLogger( ui, folderName, fileName);
    }

    public static FileSystemLogger GetInstance()
    {
        return _instance ?? throw new NullReferenceException("Instance of logger not created yet. Call CreateInstance() first.");
    }

    public void Log(LogEntry log)
    {
        if (_instance is null)
        {
            throw new InvalidOperationException("No logger instance has been created yet. Use CreateInstance() first.");
        }

        try
        {
            Directory.CreateDirectory(_logFolderName);

            string logMessage = log.ToString() + Environment.NewLine;

            if (!File.Exists(_logFilePath))
            {
                File.WriteAllText(_logFilePath, logMessage);
            }
            else
            {
                File.AppendAllText(_logFilePath, logMessage);
            }
        }
        catch (IOException ex)
        {
            _ui.PrintLine($"Failed to write log in the path '{_logFilePath}'." +
                $"Message: {ex.Message}");
            throw;
        }

    }

}