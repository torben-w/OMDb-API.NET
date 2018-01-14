using System.Collections.Generic;
using Newtonsoft.Json;

namespace OMDbApiNet.Model
{
    public class SeasonEpisode
    {
        [JsonProperty("Title")]
        public string Title { get; set; }
        
        [JsonProperty("Released")]
        public string Released { get; set; }
        
        [JsonProperty("Episode")]
        public string Episode { get; set; }
        
        [JsonProperty("imdbRating")]
        public string ImdbRating { get; set; }
        
        [JsonProperty("imdbID")]
        public string ImdbId { get; set; }
    }
    
    public class Season
    {
        [JsonProperty("Title")]
        public string Title { get; set; }
        
        [JsonProperty("Season")]
        public string SeasonNumber { get; set; }
        
        [JsonProperty("totalSeasons")]
        public string TotalSeasons { get; set; }
        
        [JsonProperty("Episodes")]
        public List<SeasonEpisode> Episodes { get; set; }
        
        [JsonProperty("Response")]
        public string Response { get; set; }
        
        [JsonProperty("Error")]
        public string Error { get; set; }
    }
}
