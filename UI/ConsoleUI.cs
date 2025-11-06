
namespace GamesReader.UI;

internal class ConsoleUI : IUI
{
    private static ConsoleUI _instance = null;
    private ConsoleUI(){
    }

    public static ConsoleUI GetInstance()
    {
        return _instance ??= new ConsoleUI();
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
