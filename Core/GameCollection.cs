using GamesReader.Models;
using GamesReader.UI.UIActions;
using GamesReader.Utils.DataFormatter;
using System.Text;

namespace GamesReader.Core;

public class GameCollection(UserInteractor userInteractor)
{
    private readonly UserInteractor _userInteractor = userInteractor;
    private readonly string _fileExtension = ".json";

    internal void Run()
    {
        string filename = _userInteractor.AskForFilename(_fileExtension);
        _userInteractor.PrintGameCollection(filename);
    }
}
