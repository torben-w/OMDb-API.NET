using System;
using System.Net.Http;
using Xunit;
using OMDbApiNet;

namespace TestOmdbApiNet
{
	/*
     * Data in these unit tests last checked on 02/02/2019 (American date format).
     */
	public class ItemAsyncTest
	{
		[Fact]
        public async void TestGetItemByTitleGood1()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey);
            var movie = await omdb.GetItemByTitleAsync("Star Wars", true);
            
            var ratings = movie.Ratings.ToArray();
            Assert.Equal("Internet Movie Database", ratings[0].Source);
            Assert.Equal("Rotten Tomatoes", ratings[1].Source);
            Assert.Equal("Metacritic", ratings[2].Source);
            
            Assert.Equal("Star Wars: Episode IV - A New Hope", movie.Title);
            Assert.Equal("1977", movie.Year);
            Assert.Equal("PG", movie.Rated);
            Assert.Equal("25 May 1977", movie.Released);
            Assert.Equal("121 min", movie.Runtime);
            Assert.Equal("George Lucas", movie.Director);
            Assert.Equal("George Lucas", movie.Writer);
            Assert.Equal("English", movie.Language);
            Assert.Equal("USA", movie.Country);
            Assert.Equal("tt0076759", movie.ImdbId);
            Assert.Equal("movie", movie.Type);
            Assert.Equal("21 Sep 2004", movie.Dvd);
            Assert.Equal("20th Century Fox", movie.Production);
            Assert.Equal("http://www.starwars.com/episode-iv/", movie.Website);
            Assert.Equal(null, movie.TotalSeasons);
            Assert.Equal("True", movie.Response);
        }
        
        [Fact]
        public async void TestGetItemByTitleGood2()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey, true);
            var movie = await omdb.GetItemByTitleAsync("Star Wars", OmdbType.Movie, 2017, false);
            
            var ratings = movie.Ratings.ToArray();
            Assert.Equal("Internet Movie Database", ratings[0].Source);
            Assert.Equal("Rotten Tomatoes", ratings[1].Source);
            Assert.Equal("Metacritic", ratings[2].Source);
            
            Assert.Equal("Star Wars: Episode VIII - The Last Jedi", movie.Title);
            Assert.Equal("2017", movie.Year);
            Assert.Equal("PG-13", movie.Rated);
            Assert.Equal("15 Dec 2017", movie.Released);
            Assert.Equal("152 min", movie.Runtime);
            Assert.Equal("Rian Johnson", movie.Director);
            Assert.Equal("English", movie.Language);
            Assert.Equal("USA", movie.Country);
            Assert.Equal("movie", movie.Type);
            Assert.Equal("http://www.rottentomatoes.com/m/star_wars_episode_viii/", movie.TomatoUrl);
            Assert.Equal("Walt Disney Pictures", movie.Production);
            Assert.Equal(null, movie.TotalSeasons);
            Assert.Equal("True", movie.Response);
        }
        
        [Fact]
        public async void TestGetItemByTitleGood3()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey, true);
            var movie = await omdb.GetItemByTitleAsync("Arrow", OmdbType.Series, 2012, false);
            
            var ratings = movie.Ratings.ToArray();
            Assert.Equal("Internet Movie Database", ratings[0].Source);
            
            Assert.Equal("Arrow", movie.Title);
            Assert.Equal("2012–", movie.Year);
            Assert.Equal("TV-14", movie.Rated);
            Assert.Equal("10 Oct 2012", movie.Released);
            Assert.Equal("42 min", movie.Runtime);
            Assert.Equal("N/A", movie.Director);
            Assert.Equal("English", movie.Language);
            Assert.Equal("USA", movie.Country);
            Assert.Equal("series", movie.Type);
            Assert.Equal("N/A", movie.Dvd);
            Assert.Equal("N/A", movie.BoxOffice);
            Assert.Equal("N/A", movie.Production);
            Assert.Equal("N/A", movie.Website);
            Assert.Equal("True", movie.Response);
        }
        
        [Fact]
        public async void TestGetItemByTitleBad()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey, true);
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetItemByTitleAsync(null));
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetItemByTitleAsync(""));
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetItemByTitleAsync(" "));
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => omdb.GetItemByTitleAsync("star wars", 1500));
        }
        
        [Fact]
        public async void TestGetItemByIdGood()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey);
            var movie = await omdb.GetItemByIdAsync("tt0076759", true);
            
            var ratings = movie.Ratings.ToArray();
            Assert.Equal("Internet Movie Database", ratings[0].Source);
            Assert.Equal("Rotten Tomatoes", ratings[1].Source);
            Assert.Equal("Metacritic", ratings[2].Source);
            
            Assert.Equal("Star Wars: Episode IV - A New Hope", movie.Title);
            Assert.Equal("1977", movie.Year);
            Assert.Equal("PG", movie.Rated);
            Assert.Equal("25 May 1977", movie.Released);
            Assert.Equal("121 min", movie.Runtime);
            Assert.Equal("George Lucas", movie.Director);
            Assert.Equal("George Lucas", movie.Writer);
            Assert.Equal("English", movie.Language);
            Assert.Equal("USA", movie.Country);
            Assert.Equal("movie", movie.Type);
            Assert.Equal("21 Sep 2004", movie.Dvd);
            Assert.Equal("N/A", movie.BoxOffice);
            Assert.Equal("20th Century Fox", movie.Production);
            Assert.Equal("http://www.starwars.com/episode-iv/", movie.Website);
            Assert.Equal("True", movie.Response);
        }

        [Fact]
        public async void TestGetItemByIdBad()
        {
            var omdb = new AsyncOmdbClient(TestData.apikey);
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetItemByIdAsync(null));
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetItemByIdAsync(""));
            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetItemByIdAsync(" "));
            
            await Assert.ThrowsAsync<HttpRequestException>(() => omdb.GetItemByIdAsync("wrongID"));
        }
	}
}
