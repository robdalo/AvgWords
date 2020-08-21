using AvgWords.Core.Consumers.MusicBrainz.Interfaces;
using AvgWords.Core.Consumers.MusicBrainz.Models;
using AvgWords.SDK.Consumers;
using System;
using System.Collections.Generic;

namespace AvgWords.Core.Consumers.MusicBrainz
{
    public class ApiConsumer : IApiConsumer
    {
        private RestConsumer _restConsumer;

        private const string GetWorkEndpoint = "work?artist=[artist]&limit=[limit]&offset=[offset]";
        private const string SearchArtistEndpoint = "artist?query=[artist]&limit=[limit]&offset=[offset]";

        public ApiConsumer(string baseUrl)
        {
            _restConsumer = new RestConsumer(baseUrl);
        }

        public List<Work> GetWorks(Guid artistId)
        {
            var limit = 100;
            var offset = 0;
            var fetched = limit;

            var works = new List<Work>();

            var url = GetWorkEndpoint.Replace("[artist]", artistId.ToString())
                                     .Replace("[limit]", limit.ToString())
                                     .Replace("[offset]", offset.ToString());

            var response = _restConsumer.Get<GetWorkResponse>(url);
            var total = response.count;

            works.AddRange(response.works);

            while (fetched < total)
            {
                offset += limit;
                url = GetWorkEndpoint.Replace("[artist]", artistId.ToString())
                                     .Replace("[limit]", limit.ToString())
                                     .Replace("[offset]", offset.ToString());

                response = _restConsumer.Get<GetWorkResponse>(url);
                works.AddRange(response.works);

                fetched += limit;
            }

            return works;
        }

        public SearchResponse Search(string artist)
        {
            var limit = 1;
            var offset = 0;

            var url = SearchArtistEndpoint.Replace("[artist]", artist)
                                          .Replace("[limit]", limit.ToString())
                                          .Replace("[offset]", offset.ToString());

            return _restConsumer.Get<SearchResponse>(url);
        }
    }
}
