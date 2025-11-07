using GamesReader.Core;
using GamesReader.Exceptions;
using GamesReader.Repositories;
using GamesReader.Services;
using GamesReader.UI;
using GamesReader.Utils.DataFormatter;
using GamesReader.Utils.Loggers;


static LoggerService GetLogger(IUI ui)
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
catch (InvalidJsonFormatException)
{
    Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");
    Console.ReadKey();
    return;
}
catch (Exception ex)
{
    try
    {
        string errorMessage = $"""
            Something unexpected has happened.
            Apologies for the inconvenience.
            """;

        Console.WriteLine(errorMessage);

        IUI consoleUI = ConsoleUI.GetInstance();
        LoggerService loggerService = GetLogger(consoleUI);
        LogEntry log = new(ex.Message, ex.StackTrace ?? "No stackTrace");

        loggerService.Log(log);
    }
    catch(Exception logEx)
    {
        Console.WriteLine($"Something failed wether in the logger or UIService: {logEx}.");
    }
}

Console.WriteLine("Press any key to close.");
Console.ReadKey();