using GamesReader;
using GamesReader.Services;
using GamesReader.UI;
using GamesReader.Utils;
using GamesReader.Utils.Loggers;


try
{
    var gameCollection = new GameCollection();
    gameCollection.Run();
}
catch (Exception ex)
{
    try
    {
        IUI consoleUI = new ConsoleUI();
        UIService uIService = new(consoleUI);
        string errorMessage = $"""
            Something unexpected has happened.
            Apologies for the inconvenience.
            Try relaunching the app.

            Message: {ex.Message}
            StackTrace: {ex.StackTrace}
            """;

        uIService.PrintLine(errorMessage);

        FileSystemLogger.CreateInstance(consoleUI);
        ILogger logger = FileSystemLogger.GetInstance();
        LoggerService loggerService = new(logger);
        LogEntry log = new(ex.Message, ex.StackTrace ?? "No stackTrace");

        loggerService.Log(log);
    }
    catch(Exception logEx)
    {
        Console.WriteLine($"Something failed wether in the logger or UIService: {logEx}." + Environment.NewLine +
            "Press any key to close the program.");
    }
}


Console.ReadKey();