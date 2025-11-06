using GamesReader.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesReader;

public class GameCollection(IUI ui)
{

    private readonly IUI _ui = ui;
    private readonly IEnumerable<string> _validFileNames =
    [
        "games",
        "gamesinvalidformat"
    ];

internal void Run()
    {
        string filename = AskForFilenameToUser();
    }

    private string AskForFilenameToUser()
    {
        bool isAValidFilename;
        string fileName;
        do
        {
            _ui.PrintLine("Enter the name of the file you want to read");
            fileName = _ui.ReadLine();
            isAValidFilename = CheckIfFileNameExists(fileName);
        } while (!isAValidFilename);
        return fileName;
    }

    private bool CheckIfFileNameExists(string fileName)
    {
        return _validFileNames.Contains(fileName.ToLower());
    }

    private void PrintGameCollection(string filename)
    {

    }
