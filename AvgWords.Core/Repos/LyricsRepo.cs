using AvgWords.Core.Consumers.LyricsOvh.Interfaces;
using AvgWords.Core.Repos.Interfaces;

namespace AvgWords.Core.Repos
{
    public class LyricsRepo : ILyricsRepo
    {
        private readonly IApiConsumer _apiConsumer;

        public LyricsRepo(IApiConsumer apiConsumer)
        {
            _apiConsumer = apiConsumer;
        }

        public string Get(string artist, string title)
        {
            var response = _apiConsumer.GetLyrics(artist, title);
            return response?.lyrics;
        }
    }
}
