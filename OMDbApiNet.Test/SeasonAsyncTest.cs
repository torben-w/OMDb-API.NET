using System;
using System.Net.Http;
using Xunit;
using OMDbApiNet;

namespace TestOmdbApiNet
{
	/*
     * Data in these unit tests last checked on 02/02/2019 (American date format).
     */
	public class SeasonAsyncTest
	{
		[Fact]
        public async void TestGetSeasonBySeriesIdGood()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey);
            var season = await omdb.GetSeasonBySeriesIdAsync("tt2193021", 1);
            
            var episodes = season.Episodes.ToArray();
            Assert.Equal("Pilot", episodes[0].Title);
            Assert.Equal("2012-10-10", episodes[0].Released);
            Assert.Equal("1", episodes[0].Episode);
            Assert.Equal("tt2340185", episodes[0].ImdbId);
            
            Assert.Equal("Honor Thy Father", episodes[1].Title);
            Assert.Equal("2012-10-17", episodes[1].Released);
            Assert.Equal("2", episodes[1].Episode);
            Assert.Equal("tt2310910", episodes[1].ImdbId);

            Assert.Equal("Damaged", episodes[4].Title);
            Assert.Equal("2012-11-07", episodes[4].Released);
            Assert.Equal("5", episodes[4].Episode);
            Assert.Equal("tt2338426", episodes[4].ImdbId);
            
            Assert.Equal("Arrow", season.Title);
            Assert.Equal("1", season.SeasonNumber);
            Assert.Equal("True", season.Response);
        }
        
        [Fact]
        public async void TestGetSeasonBySeriesIdBad()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey);
            
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetSeasonBySeriesIdAsync(null, 1));
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetSeasonBySeriesIdAsync("", 1));
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetSeasonBySeriesIdAsync(" ", 1));
            
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => omdb.GetSeasonBySeriesIdAsync("tt2193021", 0));  
                 
            await Assert.ThrowsAsync<HttpRequestException>(() => omdb.GetSeasonBySeriesIdAsync("asdf", 1));
            await Assert.ThrowsAsync<HttpRequestException>(() => omdb.GetSeasonBySeriesIdAsync("tt2193021", 100));
        }
        
                
        [Fact]
        public async void TestGetSeasonBySeriesTitleGood()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey);
            var season = await omdb.GetSeasonBySeriesTitleAsync("arrow", 1);
            
            var episodes = season.Episodes.ToArray();
            Assert.Equal("Pilot", episodes[0].Title);
            Assert.Equal("2012-10-10", episodes[0].Released);
            Assert.Equal("1", episodes[0].Episode);
            Assert.Equal("tt2340185", episodes[0].ImdbId);
            
            Assert.Equal("Honor Thy Father", episodes[1].Title);
            Assert.Equal("2012-10-17", episodes[1].Released);
            Assert.Equal("2", episodes[1].Episode);
            Assert.Equal("tt2310910", episodes[1].ImdbId);

            Assert.Equal("Damaged", episodes[4].Title);
            Assert.Equal("2012-11-07", episodes[4].Released);
            Assert.Equal("5", episodes[4].Episode);
            Assert.Equal("tt2338426", episodes[4].ImdbId);
            
            Assert.Equal("Arrow", season.Title);
            Assert.Equal("1", season.SeasonNumber);
            Assert.Equal("True", season.Response);
        }
        
        [Fact]
        public async void TestGetSeasonBySeriesTitleBad()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey);
            
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetSeasonBySeriesTitleAsync(null, 1));
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetSeasonBySeriesTitleAsync("", 1));
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetSeasonBySeriesTitleAsync(" ", 1));
            
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => omdb.GetSeasonBySeriesTitleAsync("tt2193021", 0));  
                 
            await Assert.ThrowsAsync<HttpRequestException>(() => omdb.GetSeasonBySeriesTitleAsync("asdf", 1));
            await Assert.ThrowsAsync<HttpRequestException>(() => omdb.GetSeasonBySeriesTitleAsync("arrow", 100));
        }
	}
}
