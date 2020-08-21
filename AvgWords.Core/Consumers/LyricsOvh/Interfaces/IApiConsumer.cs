using AvgWords.Core.Consumers.LyricsOvh.Models;

namespace AvgWords.Core.Consumers.LyricsOvh.Interfaces
{
    public interface IApiConsumer
    {
        GetLyricsResponse GetLyrics(string artist, string title);
    }
}
