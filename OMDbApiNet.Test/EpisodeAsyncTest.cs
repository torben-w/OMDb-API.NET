using System;
using System.Net.Http;
using Xunit;
using OMDbApiNet;

namespace TestOmdbApiNet
{
	/*
     * Data in these unit tests last checked on 02/02/2019 (American date format).
     */
	public class EpisodeAsyncTest
	{
		 [Fact]
        public async void TestGetEpisodeBySeriesIdGood()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey);
            var episode = await omdb.GetEpisodeBySeriesIdAsync("tt2193021", 1, 1);


            var ratings = episode.Ratings.ToArray();
            Assert.Equal("Internet Movie Database", ratings[0].Source);

            Assert.Equal("Pilot", episode.Title);
            Assert.Equal("2012", episode.Year);
            Assert.Equal("TV-PG", episode.Rated);
            Assert.Equal("10 Oct 2012", episode.Released);
            Assert.Equal("1", episode.SeasonNumber);
            Assert.Equal("1", episode.EpisodeNumber);
            Assert.Equal("45 min", episode.Runtime);
            Assert.Equal("David Nutter", episode.Director);
            Assert.Equal("English", episode.Language);
            Assert.Equal("USA, Canada", episode.Country);
            Assert.Equal("tt2340185", episode.ImdbId);
            Assert.Equal("tt2193021", episode.SeriesId);
            Assert.Equal("episode", episode.Type);
            Assert.Equal("True", episode.Response);
        }
        
        [Fact]
        public async void TestGetEpisodeBySeriesIdBad()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey);

            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetEpisodeBySeriesIdAsync(null, 1, 1));
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetEpisodeBySeriesIdAsync("", 1, 1));
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetEpisodeBySeriesIdAsync(" ", 1, 1));
            
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => omdb.GetEpisodeBySeriesIdAsync("tt2193021", 0, 1));
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => omdb.GetEpisodeBySeriesIdAsync("tt2193021", 1, 0));
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => omdb.GetEpisodeBySeriesIdAsync("tt2193021", 0, 0));
            
            await Assert.ThrowsAsync<HttpRequestException>(() => omdb.GetEpisodeBySeriesIdAsync("asdf", 1, 1));
            await Assert.ThrowsAsync<HttpRequestException>(() => omdb.GetEpisodeBySeriesIdAsync("tt2193021", 100, 1));
            await Assert.ThrowsAsync<HttpRequestException>(() => omdb.GetEpisodeBySeriesIdAsync("tt2193021", 1, 100));
        }
        
        [Fact]
        public async void TestGetEpisodeBySeriesTitleGood()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey);
            var episode = await omdb.GetEpisodeBySeriesTitleAsync("arrow", 1, 1);


            var ratings = episode.Ratings.ToArray();
            Assert.Equal("Internet Movie Database", ratings[0].Source);

            Assert.Equal("Pilot", episode.Title);
            Assert.Equal("2012", episode.Year);
            Assert.Equal("TV-PG", episode.Rated);
            Assert.Equal("10 Oct 2012", episode.Released);
            Assert.Equal("1", episode.SeasonNumber);
            Assert.Equal("1", episode.EpisodeNumber);
            Assert.Equal("45 min", episode.Runtime);
            Assert.Equal("David Nutter", episode.Director);
            Assert.Equal("English", episode.Language);
            Assert.Equal("USA, Canada", episode.Country);
            Assert.Equal("tt2340185", episode.ImdbId);
            Assert.Equal("tt2193021", episode.SeriesId);
            Assert.Equal("episode", episode.Type);
            Assert.Equal("True", episode.Response);
        }
        
        [Fact]
        public async void TestGetEpisodeBySeriesTitleBad()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey);

            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetEpisodeBySeriesTitleAsync(null, 1, 1));
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetEpisodeBySeriesTitleAsync("", 1, 1));
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetEpisodeBySeriesTitleAsync(" ", 1, 1));
            
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => omdb.GetEpisodeBySeriesTitleAsync("arrow", 0, 1));
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => omdb.GetEpisodeBySeriesTitleAsync("arrow", 1, 0));
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => omdb.GetEpisodeBySeriesTitleAsync("arrow", 0, 0));
            
            await Assert.ThrowsAsync<HttpRequestException>(() => omdb.GetEpisodeBySeriesTitleAsync("asdf", 1, 1));
            await Assert.ThrowsAsync<HttpRequestException>(() => omdb.GetEpisodeBySeriesTitleAsync("arrow", 100, 1));
            await Assert.ThrowsAsync<HttpRequestException>(() => omdb.GetEpisodeBySeriesTitleAsync("arrow", 1, 100));
        }
        
        [Fact]
        public async void TestGetEpisodeByEpisodeIdGood()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey);
            var episode = await omdb.GetEpisodeByEpisodeIdAsync("tt2340185");


            var ratings = episode.Ratings.ToArray();
            Assert.Equal("Internet Movie Database", ratings[0].Source);

            Assert.Equal("Pilot", episode.Title);
            Assert.Equal("2012", episode.Year);
            Assert.Equal("TV-PG", episode.Rated);
            Assert.Equal("10 Oct 2012", episode.Released);
            Assert.Equal("1", episode.SeasonNumber);
            Assert.Equal("1", episode.EpisodeNumber);
            Assert.Equal("45 min", episode.Runtime);
            Assert.Equal("David Nutter", episode.Director);
            Assert.Equal("English", episode.Language);
            Assert.Equal("USA, Canada", episode.Country);
            Assert.Equal("tt2340185", episode.ImdbId);
            Assert.Equal("tt2193021", episode.SeriesId);
            Assert.Equal("episode", episode.Type);
            Assert.Equal("True", episode.Response);
        }
        
        [Fact]
        public async void TestGetEpisodeByEpisodeIdBad()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey);

            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetEpisodeByEpisodeIdAsync(null));
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetEpisodeByEpisodeIdAsync(""));
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetEpisodeByEpisodeIdAsync(" "));

            await Assert.ThrowsAsync<HttpRequestException>(() => omdb.GetEpisodeByEpisodeIdAsync("asdf"));
        }
	}
}
