using GamesReader.Models;
using GamesReader.Services;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesReader.Utils.DataFormatter;

public class JsonDataFormatter(GameCollectionRepositoryService repositoryService)
{
    private readonly GameCollectionRepositoryService _repositoryService = repositoryService;

    public List<Game> ParseFromJsonToGames(string filename)
    {
        string dataAsJson = _repositoryService.GetGameCollectionData(filename);
        List<Game> games = JsonSerializer.Deserialize<List<Game>>(dataAsJson)
            ?? [];
        return games;
    }
}
