using AvgWords.Core.Consumers.MusicBrainz.Interfaces;
using AvgWords.Core.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvgWords.Core.Repos
{
    public class ArtistRepo : IArtistRepo
    {
        private readonly IApiConsumer _apiConsumer;

        public ArtistRepo(IApiConsumer apiConsumer)
        {
            _apiConsumer = apiConsumer;
        }

        public bool Exists(string artist)
        {
            var response = _apiConsumer.Search(artist);
            if (response != null && response.artists != null && response.artists.Any())
                return true;

            return false;
        }

        public Guid GetId(string artist)
        {
            var response = _apiConsumer.Search(artist);
            return response.artists.FirstOrDefault().id;
        }

        public List<string> GetWorks(Guid artistId)
        {
            var works = _apiConsumer.GetWorks(artistId);

            return works.OrderBy(w => w.title)
                        .Select(w => w.title)
                        .Distinct()
                        .ToList();
        }

        public List<string> GetWorks(string artist)
        {
            var artistId = GetId(artist);
            var works = _apiConsumer.GetWorks(artistId);

            return works.OrderBy(w => w.title)
                        .Select(w => w.title)
                        .Distinct()
                        .ToList();
        }
    }
}
