using GamesReader;
using GamesReader.Services;
using GamesReader.Utils;


try
{
    var gameCollection = new GameCollection();
    gameCollection.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Something unexpected has happen." +
        "Apologize for the inconvenients." +
        "Try relaunching the app.");

    LoggerService logger = new LoggerService();
    DateTime date = DateTime.Now;

    logger.Log($" Exception Message: {ex.Message}, StackTrace: {ex.StackTrace}");
}


Console.ReadKey();