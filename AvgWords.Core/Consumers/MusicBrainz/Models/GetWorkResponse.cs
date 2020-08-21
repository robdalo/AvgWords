using Newtonsoft.Json;
using System.Collections.Generic;

namespace AvgWords.Core.Consumers.MusicBrainz.Models
{
    public class GetWorkResponse
    {
        [JsonProperty("work-count")]
        public int count { get; set; }
        [JsonProperty("work-offset")]
        public int offset { get; set; }
        public List<Work> works { get; set; }
    }
}
