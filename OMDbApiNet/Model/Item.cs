using System.Collections.Generic;
using Newtonsoft.Json;

namespace OMDbApiNet.Model
{
    public class Item
    {
        [JsonProperty("Title")]
        public string Title { get; set; }
        
        [JsonProperty("Year")]
        public string Year { get; set; }
        
        [JsonProperty("Rated")]
        public string Rated { get; set; }
        
        [JsonProperty("Released")]
        public string Released { get; set; }
        
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
        
        [JsonProperty("Type")]
        public string Type { get; set; }
        
        [JsonProperty("tomatoMeter")]
        public string TomatoMeter { get; set; }
        
        [JsonProperty("tomatoImage")]
        public string TomatoImage { get; set; }
        
        [JsonProperty("tomatoRating")]
        public string TomatoRating { get; set; }
        
        [JsonProperty("tomatoReviews")]
        public string TomatoReviews { get; set; }
        
        [JsonProperty("tomatoFresh")]
        public string TomatoFresh { get; set; }
        
        [JsonProperty("tomatoRotten")]
        public string TomatoRotten { get; set; }
        
        [JsonProperty("tomatoConsensus")]
        public string TomatoConsensus { get; set; }
        
        [JsonProperty("tomatoUserMeter")]
        public string TomatoUserMeter { get; set; }
        
        [JsonProperty("tomatoUserRating")]
        public string TomatoUserRating { get; set; }
        
        [JsonProperty("tomatoUserReviews")]
        public string TomatoUserReviews { get; set; }
        
        [JsonProperty("tomatoURL")]
        public string TomatoUrl { get; set; }
        
        [JsonProperty("DVD")]
        public string Dvd { get; set; }
        
        [JsonProperty("BoxOffice")]
        public string BoxOffice { get; set; }
        
        [JsonProperty("Production")]
        public string Production { get; set; }
        
        [JsonProperty("Website")]
        public string Website { get; set; }
        
        [JsonProperty("totalSeasons")]
        public string TotalSeasons { get; set; }
        
        [JsonProperty("Response")]
        public string Response { get; set; }
        
        [JsonProperty("Error")]
        public string Error { get; set; }
    }
}
