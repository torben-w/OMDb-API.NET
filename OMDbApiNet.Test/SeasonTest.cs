using System;
using System.Net.Http;
using Xunit;
using OMDbApiNet;

namespace TestOmdbApiNet
{
    /*
     * Data in these unit tests last checked on 02/09/2018 (American date format).
     */
    public class SeasonTest
    {
        // TODO: Insert your api key here. You can get one on http://www.omdbapi.com/
        private readonly string apikey = "";
        
        [Fact]
        public void TestGetSeasonBySeriesIdGood()
        {
            var omdb = new OmdbClient(apikey);
            var season = omdb.GetSeasonBySeriesId("tt2193021", 1);
            
            var episodes = season.Episodes.ToArray();
            Assert.Equal("Pilot", episodes[0].Title);
            Assert.Equal("2012-10-10", episodes[0].Released);
            Assert.Equal("1", episodes[0].Episode);
            Assert.Equal("8.5", episodes[0].ImdbRating);
            Assert.Equal("tt2340185", episodes[0].ImdbId);
            
            Assert.Equal("Honor Thy Father", episodes[1].Title);
            Assert.Equal("2012-10-17", episodes[1].Released);
            Assert.Equal("2", episodes[1].Episode);
            Assert.Equal("8.3", episodes[1].ImdbRating);
            Assert.Equal("tt2310910", episodes[1].ImdbId);

            Assert.Equal("Damaged", episodes[4].Title);
            Assert.Equal("2012-11-07", episodes[4].Released);
            Assert.Equal("5", episodes[4].Episode);
            Assert.Equal("8.7", episodes[4].ImdbRating);
            Assert.Equal("tt2338426", episodes[4].ImdbId);
            
            Assert.Equal("Arrow", season.Title);
            Assert.Equal("1", season.SeasonNumber);
            Assert.Equal("6", season.TotalSeasons);
            Assert.Equal("True", season.Response);
        }
        
        [Fact]
        public void TestGetSeasonBySeriesIdBad()
        {
            var omdb = new OmdbClient(apikey);
            
            Assert.Throws<ArgumentException>(() => omdb.GetSeasonBySeriesId(null, 1));
            Assert.Throws<ArgumentException>(() => omdb.GetSeasonBySeriesId("", 1));
            Assert.Throws<ArgumentException>(() => omdb.GetSeasonBySeriesId(" ", 1));
            
            Assert.Throws<ArgumentOutOfRangeException>(() => omdb.GetSeasonBySeriesId("tt2193021", 0));  
                 
            Assert.Throws<HttpRequestException>(() => omdb.GetSeasonBySeriesId("asdf", 1));
            Assert.Throws<HttpRequestException>(() => omdb.GetSeasonBySeriesId("tt2193021", 100));
        }
        
                
        [Fact]
        public void TestGetSeasonBySeriesTitleGood()
        {
            var omdb = new OmdbClient(apikey);
            var season = omdb.GetSeasonBySeriesTitle("arrow", 1);
            
            var episodes = season.Episodes.ToArray();
            Assert.Equal("Pilot", episodes[0].Title);
            Assert.Equal("2012-10-10", episodes[0].Released);
            Assert.Equal("1", episodes[0].Episode);
            Assert.Equal("8.5", episodes[0].ImdbRating);
            Assert.Equal("tt2340185", episodes[0].ImdbId);
            
            Assert.Equal("Honor Thy Father", episodes[1].Title);
            Assert.Equal("2012-10-17", episodes[1].Released);
            Assert.Equal("2", episodes[1].Episode);
            Assert.Equal("8.3", episodes[1].ImdbRating);
            Assert.Equal("tt2310910", episodes[1].ImdbId);

            Assert.Equal("Damaged", episodes[4].Title);
            Assert.Equal("2012-11-07", episodes[4].Released);
            Assert.Equal("5", episodes[4].Episode);
            Assert.Equal("8.7", episodes[4].ImdbRating);
            Assert.Equal("tt2338426", episodes[4].ImdbId);
            
            Assert.Equal("Arrow", season.Title);
            Assert.Equal("1", season.SeasonNumber);
            Assert.Equal("6", season.TotalSeasons);
            Assert.Equal("True", season.Response);
        }
        
        [Fact]
        public void TestGetSeasonBySeriesTitleBad()
        {
            var omdb = new OmdbClient(apikey);
            
            Assert.Throws<ArgumentException>(() => omdb.GetSeasonBySeriesTitle(null, 1));
            Assert.Throws<ArgumentException>(() => omdb.GetSeasonBySeriesTitle("", 1));
            Assert.Throws<ArgumentException>(() => omdb.GetSeasonBySeriesTitle(" ", 1));
            
            Assert.Throws<ArgumentOutOfRangeException>(() => omdb.GetSeasonBySeriesTitle("tt2193021", 0));  
                 
            Assert.Throws<HttpRequestException>(() => omdb.GetSeasonBySeriesTitle("asdf", 1));
            Assert.Throws<HttpRequestException>(() => omdb.GetSeasonBySeriesTitle("arrow", 100));
        }
    }
}
