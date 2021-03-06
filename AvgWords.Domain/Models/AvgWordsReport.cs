﻿using System.Collections.Generic;

namespace AvgWords.Domain.Models
{
    public class AvgWordsReport
    {
        public string Artist { get; set; }
        public int NumberOfSongs { get; set; }
        public int NumberOfWords { get; set; }
        public decimal AverageWordsPerSong { get; set; }
        public Dictionary<string, int> Songs { get; set; }
        public string ErrorMessage { get; set; }
    }
}
