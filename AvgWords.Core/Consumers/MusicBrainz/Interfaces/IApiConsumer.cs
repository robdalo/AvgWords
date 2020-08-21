using AvgWords.Core.Consumers.MusicBrainz.Models;
using System;
using System.Collections.Generic;

namespace AvgWords.Core.Consumers.MusicBrainz.Interfaces
{
    public interface IApiConsumer
    {
        List<Work> GetWorks(Guid artistId);
        SearchResponse Search(string artist);
    }
}
