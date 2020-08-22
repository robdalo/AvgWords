using AvgWords.Core.Repos.Interfaces;
using AvgWords.Core.Services;
using AvgWords.Core.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace AvgWords.Core.Tests.Unit.Services
{
    public class ArtistServiceTests
    {
        private readonly Mock<IArtistRepo> _artistRepo;
        private readonly Mock<ILyricsRepo> _lyricsRepo;

        private readonly IReportService _reportService;

        public ArtistServiceTests()
        {
            _artistRepo = new Mock<IArtistRepo>();
            _lyricsRepo = new Mock<ILyricsRepo>();
            _reportService = new ReportService(_artistRepo.Object, _lyricsRepo.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenGetAvgWordsPerSong_ReturnsAvgWordsPerSong()
        {
            var artist = "Coldplay";
            var expected = 7.5m;

            _artistRepo.Setup(ar => ar.GetWorks(It.IsAny<string>()))
                       .Returns(new List<string> { "Clocks", "Yellow" });
            _lyricsRepo.Setup(lr => lr.Get(It.IsAny<string>(), "Clocks"))
                       .Returns("lights go out and I can't be saved");
            _lyricsRepo.Setup(lr => lr.Get(It.IsAny<string>(), "Yellow"))
                       .Returns("Oh what a thing to have done");

            var avgWordsReport = _reportService.GetAvgWordsReport(artist);

            Assert.True(
                avgWordsReport.AverageWordsPerSong == expected
            );
        }
    }
}
