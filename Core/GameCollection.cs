using GamesReader.Models;
using GamesReader.UI;
using GamesReader.Utils.DataFormatter;
using System.Text;

namespace GamesReader.Core;

public class GameCollection(IUI ui, JsonDataFormatter jsonDataFormatter)
{
    private readonly JsonDataFormatter _jsonDataFormatter = jsonDataFormatter;
    private readonly IUI _ui = ui;

    private readonly IEnumerable<string> _validFileNames =
    [
        "games",
        "gamesinvalidformat"
    ];
    private readonly string _fileExtension = ".json";

    internal void Run()
    {
        string filename = AskForFilenameToUser();
        PrintGameCollection(filename);
    }

    private string AskForFilenameToUser()
    {
        bool isAValidFilename = false;
        string fileName;
        do
        {
            _ui.PrintLine("Enter the name of the file you want to read");
            fileName = _ui.ReadLine();            
            isAValidFilename = ValidateUserInput(fileName);
        } while (!isAValidFilename);
        return fileName + _fileExtension;
    }

    private bool ValidateUserInput(string input)
    {
        if (input is null)
        {
            _ui.PrintLine("File name cannot be null.");
            return false;
        }
        else if (input.Trim() == string.Empty)
        {
            _ui.PrintLine("File name cannot be empty.");
            return false;
        }
        else if (!CheckIfFileNameExists(input))
        {
            _ui.PrintLine("File not found.");
            return false;
        }
        else
        {
            return CheckIfFileNameExists(input);
        }
    }

    private bool CheckIfFileNameExists(string fileName)
    {
        return _validFileNames.Contains(fileName.ToLower());
    }

    private void PrintGameCollection(string filename)
    {
        List<Game> games = _jsonDataFormatter.ParseFromJsonToGames(filename);
        if( games.Count == 0)
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
