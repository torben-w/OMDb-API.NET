using System;
using System.Net.Http;
using Xunit;
using OMDbApiNet;

namespace TestOmdbApiNet
{
    /*
     * Data in these unit tests last checked on 02/09/2018 (American date format).
     */
    public class SearchTest
    {
        // TODO: Insert your api key here. You can get one on http://www.omdbapi.com/
        private readonly string apikey = "";
        
        [Fact]
        public void TestGetSearchListGood()
        {
            var omdb = new OmdbClient(apikey);
            var searchList = omdb.GetSearchList("Arrow", 1);

            var search = searchList.SearchResults.ToArray();
            Assert.Equal("Arrow", search[0].Title);
            Assert.Equal("2012–", search[0].Year);
            Assert.Equal("tt2193021", search[0].ImdbId);
            Assert.Equal("series", search[0].Type);
            Assert.Equal("https://images-na.ssl-images-amazon.com/images/M/MV5BMTUwOTgyNTQ1M15BMl5BanBnXkFtZTgwNDEyNzM3MzI@._V1_SX300.jpg", search[0].Poster);
            
            Assert.Equal("Broken Arrow", search[1].Title);
            Assert.Equal("1996", search[1].Year);
            Assert.Equal("tt0115759", search[1].ImdbId);
            Assert.Equal("movie", search[1].Type);
            Assert.Equal("https://images-na.ssl-images-amazon.com/images/M/MV5BYzU2NDg3ZTItNzRmNy00NTQzLTljMDUtNjczOTMwZjEzNWVkXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg", search[1].Poster);

            Assert.Equal("Green Arrow", search[5].Title);
            Assert.Equal("2010", search[5].Year);
            Assert.Equal("tt1663633", search[5].ImdbId);
            Assert.Equal("movie", search[5].Type);
            Assert.Equal("https://images-na.ssl-images-amazon.com/images/M/MV5BZDMxZTU5OTgtZDdlOS00NTRiLWFhZTItYjUwYzc2NzZmNTYxXkEyXkFqcGdeQXVyNTcxMDM0OTA@._V1_SX300.jpg", search[5].Poster);

            Assert.Equal("159", searchList.TotalResults);
            Assert.Equal(null, searchList.Error);
            Assert.Equal("True", searchList.Response);
        }
        
        [Fact]
        public void TestGetSearchListBad()
        {
            var omdb = new OmdbClient(apikey);
            
            Assert.Throws<ArgumentException>(() => omdb.GetSearchList(null));
            Assert.Throws<ArgumentException>(() => omdb.GetSearchList(""));
            Assert.Throws<ArgumentException>(() => omdb.GetSearchList(" "));
            
            Assert.Throws<ArgumentOutOfRangeException>(() => omdb.GetSearchList("star wars", 0));
            
            Assert.Throws<ArgumentOutOfRangeException>(() => omdb.GetSearchList(1500, "star wars", 0));
            
            Assert.Throws<HttpRequestException>(() => omdb.GetSearchList("asdf"));
        }
    }
}
