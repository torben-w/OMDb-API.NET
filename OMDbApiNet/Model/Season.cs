using System.Collections.Generic;

namespace OMDbApiNet.Model
{
    public class SeasonEpisode
    {
        public string Title { get; set; }
        public string Released { get; set; }
        public string Episode { get; set; }
        public string ImdbRating { get; set; }
        public string ImdbID { get; set; }
    }
    
    public class Season
    {
        public string Title { get; set; }
        public string SeasonNumber { get; set; }
        public string TotalSeasons { get; set; }
        public List<SeasonEpisode> Episodes { get; set; }
        public string Response { get; set; }
    }
}
