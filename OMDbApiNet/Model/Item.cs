using System.Collections.Generic;

namespace OMDbApiNet.Model
{
    public class Item
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public List<Rating> Ratings { get; set; }
        public string Metascore { get; set; }
        public string ImdbRating { get; set; }
        public string ImdbVotes { get; set; }
        public string ImdbId { get; set; }
        public string Type { get; set; }
        public string TomatoMeter { get; set; }
        public string TomatoImage { get; set; }
        public string TomatoRating { get; set; }
        public string TomatoReviews { get; set; }
        public string TomatoFresh { get; set; }
        public string TomatoRotten { get; set; }
        public string TomatoConsensus { get; set; }
        public string TomatoUserMeter { get; set; }
        public string TomatoUserRating { get; set; }
        public string TomatoUserReviews { get; set; }
        public string TomatoUrl { get; set; }
        public string Dvd { get; set; }
        public string BoxOffice { get; set; }
        public string Production { get; set; }
        public string Website { get; set; }
        public string Response { get; set; }
    }
}
