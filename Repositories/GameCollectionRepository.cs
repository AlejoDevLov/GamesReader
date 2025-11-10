using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesReader.Repositories
{
    public class GameCollectionRepository : IGameCollectionRepository
    {
        private readonly string _basePath = "Data";
        private readonly IEnumerable<string> _validFileNames =
    [
        "games",
        "gamesinvalidformat"
    ];

        public IEnumerable<string> GetAvailableFileNames()
        {
            return _validFileNames;
        }

        public string GetGameCollectionData(string filename)
        {
            filename = filename.ToLower();
            string fullPath = Path.Combine(_basePath, filename);
            string data = File.ReadAllText(fullPath);
            return data;
        }
    }
}
