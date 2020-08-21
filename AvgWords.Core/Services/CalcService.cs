using AvgWords.Core.Repos.Interfaces;
using AvgWords.Core.Services.Interfaces;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace AvgWords.Core.Services
{
    public class CalcService : ICalcService
    {
        private readonly IArtistRepo _artistRepo;
        private readonly ILyricsRepo _lyricsRepo;

        public CalcService(IArtistRepo artistRepo, ILyricsRepo lyricsRepo)
        {
            _artistRepo = artistRepo;
            _lyricsRepo = lyricsRepo;
        }

        public decimal GetAvgWordsPerSong(string artist)
        {
            var titles = _artistRepo.GetWorks(artist);
            var wordCounts = new ConcurrentBag<int>();

            Parallel.ForEach(titles, title =>
            {
                var lyrics = _lyricsRepo.Get(artist, title);

                if (lyrics == null)
                    return;

                var words = lyrics.Split(' ').ToList();
                wordCounts.Add(words.Count);
            });

            var total = (decimal)(wordCounts.Sum(wc => wc));
            var number = (decimal)(wordCounts.Count);

            var average = total / number;

            return average;
        }
    }
}
