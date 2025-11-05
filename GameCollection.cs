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

    internal void Run()
    {
        throw new NotImplementedException();
    }

    private void AskGamelistnameToUser()
    {
        do
        {
            _ui.PrintLine("Enter the name of the file you want to read");
            string fileName = _ui.ReadLine();

        } while ();
    }

    private bool CheckIfFileNameExists(string fileName)
    {

    }
}
