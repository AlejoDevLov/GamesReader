using GamesReader.UI.UIActions;


namespace GamesReader.Core;

public class GameCollection(UserInteractor userInteractor)
{
    private readonly UserInteractor _userInteractor = userInteractor;

    internal void Run()
    {
        string filename = _userInteractor.AskForFilename();
        _userInteractor.PrintGameCollection(filename);
    }
}
