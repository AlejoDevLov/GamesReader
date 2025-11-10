using GamesReader.Core;
using GamesReader.Exceptions;
using GamesReader.Logging;
using GamesReader.Repositories;
using GamesReader.Services;
using GamesReader.UI;
using GamesReader.UI.UIActions;
using GamesReader.UI.UserInterface;
using GamesReader.Utils.DataFormatter;


static LoggerService GetLogger(IUI ui)
{
    FileSystemLogger.CreateInstance(ui);
    ILogger logger = FileSystemLogger.GetInstance();
    return new LoggerService(logger);   
}

try
{
    IUI consoleUI = ConsoleUI.GetInstance();
    LoggerService loggerService = GetLogger(consoleUI);

    var  gameCollectionRepository = new GameCollectionRepository();
    var repositoryService = new GameCollectionRepositoryService(gameCollectionRepository);
    var jsonDataFormatter = new JsonDataFormatter(repositoryService, consoleUI, loggerService);
    var userDataValidator = new UserDataValidator(repositoryService.GetAvailableFileNames(), consoleUI);
    var userInteractor = new UserInteractor(consoleUI, jsonDataFormatter, userDataValidator);
    var gameCollection = new GameCollection(userInteractor);

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