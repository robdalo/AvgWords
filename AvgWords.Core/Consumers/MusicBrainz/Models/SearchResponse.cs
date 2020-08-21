using System;
using System.Collections.Generic;

namespace AvgWords.Core.Consumers.MusicBrainz.Models
{
    public class SearchResponse
    {
        public DateTime created { get; set; }
        public int count { get; set; }
        public int offset { get; set; }
        public List<Artist> artists { get; set; }
    }
}
