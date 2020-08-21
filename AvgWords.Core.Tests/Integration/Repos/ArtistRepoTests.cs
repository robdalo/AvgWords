using AvgWords.Core.Consumers.MusicBrainz;
using AvgWords.Core.Consumers.MusicBrainz.Interfaces;
using AvgWords.Core.Repos;
using AvgWords.Core.Repos.Interfaces;
using NUnit.Framework;
using System.Linq;

namespace AvgWords.Core.Tests.Integration.Repos
{
    public class ArtistRepoTests
    {
        private readonly IApiConsumer _apiConsumer;
        private readonly IArtistRepo _artistRepo;

        private const string BaseUrl = "https://musicbrainz.org/ws/2";

        public ArtistRepoTests()
        {
            _apiConsumer = new ApiConsumer(BaseUrl);
            _artistRepo = new ArtistRepo(_apiConsumer);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenGetId_ReturnId()
        {
            var artist = "Coldplay";
            var artistId = _artistRepo.GetId(artist);

            Assert.True(
                artistId != null && artistId.ToString() == "cc197bad-dc9c-440d-a5b5-d52ba2e14234"
            );
        }

        [Test]
        public void WhenGetWorks_ReturnsWorks()
        {
            var artist = "Coldplay";
            var works = _artistRepo.GetWorks(artist);

            Assert.True(
                works != null && works.Any() && 
                works.Any(w => w == "Clocks") &&
                works.Any(w => w == "Yellow")
            );
        }
    }
}
