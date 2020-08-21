using AvgWords.Core.Consumers.LyricsOvh;
using AvgWords.Core.Consumers.LyricsOvh.Interfaces;
using AvgWords.Core.Repos;
using AvgWords.Core.Repos.Interfaces;
using NUnit.Framework;

namespace AvgWords.Core.Tests.Integration.Repos
{
    public class LyricsRepoTests
    {
        private readonly IApiConsumer _apiConsumer;
        private readonly ILyricsRepo _lyricsRepo;

        private const string BaseUrl = "https://api.lyrics.ovh/v1";

        public LyricsRepoTests()
        {
            _apiConsumer = new ApiConsumer(BaseUrl);
            _lyricsRepo = new LyricsRepo(_apiConsumer);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenGetLyrics_ReturnLyrics()
        {
            var artist = "Coldplay";
            var title = "Clocks";

            var lyrics = _lyricsRepo.Get(artist, title);

            Assert.True(
                !string.IsNullOrEmpty(lyrics) && lyrics.Contains("lights go out and I can't be saved")
            );
        }
    }
}
