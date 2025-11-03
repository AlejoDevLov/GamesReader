
namespace GamesReader.UI;

internal class ConsoleUI : IUI
{
    public void PrintLine(string message)
    {
        Console.WriteLine(message);
    }

    public string ReadLine()
    {
        return Console.ReadLine() ?? "";
    }
}
