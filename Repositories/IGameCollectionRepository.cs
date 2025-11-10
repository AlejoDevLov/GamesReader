using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesReader.Repositories
{
    public interface IGameCollectionRepository
    {
        IEnumerable<string> GetAvailableFileNames();
        string GetGameCollectionData(string filename);
    }
}
