using AvgWords.Core.Repos;
using AvgWords.Core.Repos.Interfaces;
using AvgWords.Core.Services;
using AvgWords.Core.Services.Interfaces;
using NUnit.Framework;

namespace AvgWords.Core.Tests.Integration.Services
{
    public class ArtistServiceTests
    {
        private readonly IArtistRepo _artistRepo;
        private readonly ILyricsRepo _lyricsRepo;
        private readonly IReportService _reportService;

        private const string MusicBrainzBaseUrl = "https://musicbrainz.org/ws/2";
        private const string LyricsOvhBaseUrl = "https://api.lyrics.ovh/v1";

        public ArtistServiceTests()
        {
            var musicBrainzApiConsumer = new Consumers.MusicBrainz.ApiConsumer(MusicBrainzBaseUrl);
            var lyricsOvhApiConsumer = new Consumers.LyricsOvh.ApiConsumer(LyricsOvhBaseUrl);

            _artistRepo = new ArtistRepo(musicBrainzApiConsumer);
            _lyricsRepo = new LyricsRepo(lyricsOvhApiConsumer);
            _reportService = new ReportService(_artistRepo, _lyricsRepo);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenGetAvgWordsPerSong_ReturnsAvgWordsPerSong()
        {
            var artist = "Coldplay";
            var avgWordsReport = _reportService.GetAvgWordsReport(artist);

            Assert.True(
                avgWordsReport.AverageWordsPerSong > 0
            );
        }
    }
}
