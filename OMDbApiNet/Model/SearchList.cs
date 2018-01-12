using System.Collections.Generic;

namespace OMDbApiNet.Model
{
    public class SearchItem
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImdbId { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }

    public class SearchList
    {
        public List<SearchItem> Search { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }
    }
}
