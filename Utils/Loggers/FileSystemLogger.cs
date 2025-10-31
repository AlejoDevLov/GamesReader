using System.IO;


namespace GamesReader.Utils.Loggers;

public class FileSystemLogger(string folderName = "Logs", string fileName = "error_log.txt") : ILogger
{
    private readonly string _logFolderName = folderName;
    private readonly string _logFileName = fileName;
    private readonly string _logFilePath = Path.Combine(folderName, fileName);

    public void Log(LogEntry log)
    {
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
            Console.WriteLine($"Failed to write to log file: {ex.Message}");
        }
    }

}