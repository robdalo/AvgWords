using System;
using System.Collections.Generic;

namespace AvgWords.Core.Repos.Interfaces
{
    public interface IArtistRepo
    {
        Guid GetId(string artist);
        List<string> GetWorks(Guid artistId);
        List<string> GetWorks(string artist);
    }
}
