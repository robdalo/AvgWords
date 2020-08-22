using System;
using System.Collections.Generic;

namespace AvgWords.Core.Repos.Interfaces
{
    public interface IArtistRepo
    {
        bool Exists(string artist);
        Guid GetId(string artist);
        List<string> GetWorks(Guid artistId);
        List<string> GetWorks(string artist);
    }
}
