using GamesReader.Models;
using GamesReader.Services;
using System.Text.Json;

using GamesReader.UI;
using GamesReader.Exceptions;

namespace GamesReader.Utils.DataFormatter;

public class JsonDataFormatter(GameCollectionRepositoryService repositoryService, IUI ui, LoggerService logger)
{
    private readonly GameCollectionRepositoryService _repositoryService = repositoryService;
    private readonly IUI _ui = ui;
    private readonly LoggerService _logger = logger;

    public List<Game> ParseFromJsonToGames(string filename)
    {
        string dataAsJson = _repositoryService.GetGameCollectionData(filename);
        try
        {
            List<Game> games = JsonSerializer.Deserialize<List<Game>>(dataAsJson)
                ?? [];
            return games;
        }
        catch(JsonException ex)
        {
            _ui.PrintLine($"JSON in the {filename}  was not in a valid format. JSON body:" +
                $"{dataAsJson}");
            _logger.Log(new(ex.Message, ex.StackTrace ?? ""));

            throw new InvalidJsonFormatException(ex.Message, ex);
        }
    }
}
