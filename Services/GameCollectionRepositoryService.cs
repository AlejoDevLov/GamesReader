using GamesReader.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesReader.Services
{
    public class GameCollectionRepositoryService(IGameCollectionRepository repository)
    {
        private readonly IGameCollectionRepository _repository = repository;

        public string GetGameCollectionData(string filename)
        {
            return _repository.GetGameCollectionData(filename);
        }

        internal IEnumerable<string> GetAvailableFileNames()
        {
            return _repository.GetAvailableFileNames();
        }
    }
}
