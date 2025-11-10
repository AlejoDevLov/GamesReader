
namespace GamesReader.UI;

internal class ConsoleUI : IUI
{
    private static ConsoleUI? _instance = null;
    private ConsoleUI(){
    }

    public static ConsoleUI GetInstance()
    {
        return _instance ??= new ConsoleUI();
    }

    public void PrintError(string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        PrintLine(message);
        Console.ForegroundColor = originalColor;
    }

    public void PrintLine(string message)
    {
        Console.WriteLine(message);
    }

    public string ReadLine()
    {
        return Console.ReadLine() ?? "";
    }


}
