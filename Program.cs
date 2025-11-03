using GamesReader;
using GamesReader.Services;
using GamesReader.Utils;
using GamesReader.Utils.Loggers;


try
{
    var gameCollection = new GameCollection();
    gameCollection.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Something unexpected has happen." + Environment.NewLine +
        "Apologize for the inconvenients." + Environment.NewLine +
        "Try relaunching the app." + Environment.NewLine +
        "Message: " + ex.Message + Environment.NewLine +
        "StackTrace: " + ex.StackTrace);

    try
    {
        FileSystemLogger.CreateInstance();
        ILogger logger = FileSystemLogger.GetInstance();

        LoggerService loggerService = new(logger);
        LogEntry log = new(ex.Message, ex.StackTrace ?? "No stackTrace");

        loggerService.Log(log);
    }
    catch(Exception logEx)
    {
        Console.WriteLine($"Failed to log the error: {logEx}." + Environment.NewLine +
            "Press any key to close the program.");
    }
}


Console.ReadKey();