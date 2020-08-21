using AvgWords.Core.Consumers.LyricsOvh.Interfaces;
using AvgWords.Core.Consumers.LyricsOvh.Models;
using AvgWords.SDK.Consumers;

namespace AvgWords.Core.Consumers.LyricsOvh
{
    public class ApiConsumer : IApiConsumer
    {
        private RestConsumer _restConsumer;
        
        private const string GetLyricsEndpoint = "[artist]/[title]";

        public ApiConsumer(string baseUrl)
        {
            _restConsumer = new RestConsumer(baseUrl);
        }

        public GetLyricsResponse GetLyrics(string artist, string title)
        {
            var url = GetLyricsEndpoint.Replace("[artist]", artist)
                                       .Replace("[title]", title);

            return _restConsumer.Get<GetLyricsResponse>(url);
        }
    }
}
