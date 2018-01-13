using System.Collections.Generic;
using Newtonsoft.Json;

namespace OMDbApiNet.Model
{
    public class Episode
    {
        [JsonProperty("Title")]
        public string Title { get; set; }
        
        [JsonProperty("Year")]
        public string Year { get; set; }
        
        [JsonProperty("Rated")]
        public string Rated { get; set; }
        
        [JsonProperty("Released")]
        public string Released { get; set; }
        
        [JsonProperty("Season")]
        public string SeasonNumber { get; set; }
        
        [JsonProperty("Episode")]
        public string EpisodeNumber { get; set; }
        
        [JsonProperty("Runtime")]
        public string Runtime { get; set; }
        
        [JsonProperty("Genre")]
        public string Genre { get; set; }
        
        [JsonProperty("Director")]
        public string Director { get; set; }
        
        [JsonProperty("Writer")]
        public string Writer { get; set; }
        
        [JsonProperty("Actors")]
        public string Actors { get; set; }
        
        [JsonProperty("Plot")]
        public string Plot { get; set; }
        
        [JsonProperty("Language")]
        public string Language { get; set; }
        
        [JsonProperty("Country")]
        public string Country { get; set; }
        
        [JsonProperty("Awards")]
        public string Awards { get; set; }
        
        [JsonProperty("Poster")]
        public string Poster { get; set; }
        
        [JsonProperty("Ratings")]
        public List<Rating> Ratings { get; set; }
        
        [JsonProperty("Metascore")]
        public string Metascore { get; set; }
        
        [JsonProperty("imdbRating")]
        public string ImdbRating { get; set; }
        
        [JsonProperty("imdbVotes")]
        public string ImdbVotes { get; set; }
        
        [JsonProperty("imdbID")]
        public string ImdbId { get; set; }
        
        [JsonProperty("seriesID")]
        public string SeriesId { get; set; }
        
        [JsonProperty("Type")]
        public string Type { get; set; }
        
        [JsonProperty("Response")]
        public string Response { get; set; }
    }
}
