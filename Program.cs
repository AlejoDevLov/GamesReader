using GamesReader;
using GamesReader.Repositories;
using GamesReader.Services;
using GamesReader.UI;
using GamesReader.Utils.DataFormatter;
using GamesReader.Utils.Loggers;


LoggerService GetLogger(IUI ui)
{
    FileSystemLogger.CreateInstance(ui);
    ILogger logger = FileSystemLogger.GetInstance();
    return new LoggerService(logger);   
}

try
{
    IUI consoleUI = ConsoleUI.GetInstance();
    GameCollectionRepository gameCollectionRepository = new();
    GameCollectionRepositoryService repositoryService = new(gameCollectionRepository);
    LoggerService loggerService = GetLogger(consoleUI);
    JsonDataFormatter jsonDataFormatter = new(repositoryService, consoleUI, loggerService);
    var gameCollection = new GameCollection(consoleUI, jsonDataFormatter);
    gameCollection.Run();
}
catch (Exception ex)
{
    try
    {
        IUI consoleUI = ConsoleUI.GetInstance();
        UIService uIService = new(consoleUI);
        string errorMessage = $"""
            Something unexpected has happened.
            Apologies for the inconvenience.
            """;

        uIService.PrintLine(errorMessage);

        LoggerService loggerService = GetLogger(consoleUI);
        LogEntry log = new(ex.Message, ex.StackTrace ?? "No stackTrace");

        loggerService.Log(log);
    }
    catch(Exception logEx)
    {
        Console.WriteLine($"Something failed wether in the logger or UIService: {logEx}." + Environment.NewLine +
            "Press any key to close the program.");
    }
}

Console.WriteLine("Press any key to close.");
Console.ReadKey();