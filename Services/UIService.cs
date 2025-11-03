using GamesReader.UI;


namespace GamesReader.Services;

internal class UIService(IUI ui)
{
    private readonly IUI _ui = ui;

    public void PrintLine(string message)
    {
        _ui.PrintLine(message);
    }

    public string ReadLine()
    {
        return _ui.ReadLine();
    }
}
