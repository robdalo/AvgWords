using System.Linq;

namespace AvgWords.Mapping
{
    public static class AvgWordsReportMapper
    {
        public static SDK.Models.AvgWordsReport DomainToSDK(Domain.Models.AvgWordsReport domain)
        {
            var sdk = new SDK.Models.AvgWordsReport
            {
                Artist = domain.Artist,
                NumberOfSongs = domain.NumberOfSongs,
                NumberOfWords = domain.NumberOfWords,
                AverageWordsPerSong = domain.AverageWordsPerSong,
                Songs = domain.Songs.OrderBy(s => s.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
            };

            return sdk;
        }
    }
}
