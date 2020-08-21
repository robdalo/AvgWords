using System;

namespace AvgWords.Core.Consumers.MusicBrainz.Models
{
    public class Work
    {
        public Guid id { get; set; }
        public string type { get; set; }
        public string title { get; set; }
    }
}
