using AvgWords.Core.Repos.Interfaces;
using AvgWords.Core.Services.Interfaces;
using AvgWords.Domain.Models;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AvgWords.Core.Services
{
    public class ReportService : IReportService
    {
        private readonly IArtistRepo _artistRepo;
        private readonly ILyricsRepo _lyricsRepo;

        public ReportService(IArtistRepo artistRepo, ILyricsRepo lyricsRepo)
        {
            _artistRepo = artistRepo;
            _lyricsRepo = lyricsRepo;
        }

        public AvgWordsReport GetAvgWordsReport(string artist)
        {
            var exists = _artistRepo.Exists(artist);
            if (!exists)
                return new AvgWordsReport { ErrorMessage = "Artist of this name could not be found" };

            var titles = _artistRepo.GetWorks(artist);

            var songs = new ConcurrentDictionary<string, int>();

            Parallel.ForEach(titles, title =>
            {
                var lyrics = _lyricsRepo.Get(artist, title);

                if (lyrics == null)
                    return;

                var words = lyrics.Split(' ').ToList();
                songs.TryAdd(title, words.Count);
            });

            var avgWordsReport = new AvgWordsReport
            {
                Artist = artist,
                NumberOfSongs = songs.Count,
                NumberOfWords = songs.Sum(s => s.Value),
                Songs = songs.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
            };

            avgWordsReport.AverageWordsPerSong = (decimal)(avgWordsReport.NumberOfWords) / (decimal)(avgWordsReport.NumberOfSongs);

            return avgWordsReport;
        }
    }
}
