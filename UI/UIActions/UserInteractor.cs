using GamesReader.Models;
using GamesReader.Utils.DataFormatter;
using System.Text;

namespace GamesReader.UI.UIActions;

public class UserInteractor
{
    private readonly IUI _ui;
    private readonly JsonDataFormatter _jsonDataFormatter;
    private readonly UserDataValidator _userDataValidator;

    public UserInteractor(IUI ui, JsonDataFormatter jsonDataFormatter, UserDataValidator userDataValidator)
    {
        _ui = ui;
        _jsonDataFormatter = jsonDataFormatter;
        _userDataValidator = userDataValidator;
    }

    public string AskForFilename(string fileExtension)
    {
        bool isAValidFilename = false;
        string fileName;
        do
        {
            _ui.PrintLine("Enter the name of the file you want to read");
            fileName = _ui.ReadLine();
            isAValidFilename = _userDataValidator.ValidateInput(fileName);
        } while (!isAValidFilename);
        return fileName + fileExtension;
    }

    public void PrintGameCollection(string filename)
    {
        List<Game> games = _jsonDataFormatter.ParseFromJsonToGames(filename);
        if (games.Count == 0)
        {
            _ui.PrintLine("No games found in the collection.");
        }
        else
        {
            StringBuilder sb = new();
            sb.AppendLine("Loaded games are:");
            foreach (var game in games)
            {
                sb.AppendLine($"- {game.Title} ({game.ReleaseYear}), Rating: {game.Rating}");
            }
            _ui.PrintLine(sb.ToString());
        }
    }
}