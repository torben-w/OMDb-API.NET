using System.Collections.Generic;

namespace OMDbApiNet.Model
{
    public class Season
    {
        public string Title { get; set; }
        public string SeriesId { get; set; }
        public string SeasonNumber { get; set; }
        public string TotalSeasons { get; set; }
        public List<Episode> Episodes { get; set; }
        public string Response { get; set; }
    }
}