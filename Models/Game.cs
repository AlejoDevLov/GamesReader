
namespace GamesReader.Models
{
    internal class Game(string title, int releaseYear, float rating)
    {
        public string Title { get; } = title;
        public int ReleaseYear { get; } = releaseYear;
        public float Rating { get; } = rating;
    }
}
