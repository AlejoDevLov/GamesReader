using GamesReader.Services;
using GamesReader.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesReader;

public class GameCollection(IUI ui, GameCollectionRepositoryService repositoryService)
{
    private readonly GameCollectionRepositoryService _repositoryService = repositoryService;
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
        string data = _repositoryService.GetGameCollectionData(filename);
        _ui.PrintLine(data);
    }
}
