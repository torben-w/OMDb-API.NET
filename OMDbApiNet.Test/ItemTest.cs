using System;
using System.Net.Http;
using Xunit;
using OMDbApiNet;

namespace TestOmdbApiNet
{
    /*
     * Data in these unit tests last checked on 02/02/2019 (American date format).
     */
    public class ItemTest
    {
        [Fact]
        public void TestGetItemByTitleGood1()
        {
            var omdb = new OmdbClient(TestData.apikey);
            var movie = omdb.GetItemByTitle("Star Wars", true);
            
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
            Assert.Null(movie.TotalSeasons);
            Assert.Equal("True", movie.Response);
        }
        
        [Fact]
        public void TestGetItemByTitleGood2()
        {
            var omdb = new OmdbClient(TestData.apikey, true);
            var movie = omdb.GetItemByTitle("Star Wars", OmdbType.Movie, 2017, false);
            
            var ratings = movie.Ratings.ToArray();
            Assert.Equal("Internet Movie Database", ratings[0].Source);
            Assert.Equal("Rotten Tomatoes", ratings[1].Source);
            Assert.Equal("Metacritic", ratings[2].Source);
            
            Assert.Equal("Star Wars: The Last Jedi", movie.Title);
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
            Assert.Null(movie.TotalSeasons);
            Assert.Equal("True", movie.Response);
        }
        
        [Fact]
        public void TestGetItemByTitleGood3()
        {
            var omdb = new OmdbClient(TestData.apikey, true);
            var movie = omdb.GetItemByTitle("Arrow", OmdbType.Series, 2012, false);
            
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
        public void TestGetItemByTitleBad()
        {
            var omdb = new OmdbClient(TestData.apikey, true);
            Assert.Throws<ArgumentException>(() => omdb.GetItemByTitle(null));
            Assert.Throws<ArgumentException>(() => omdb.GetItemByTitle(""));
            Assert.Throws<ArgumentException>(() => omdb.GetItemByTitle(" "));
            Assert.Throws<ArgumentOutOfRangeException>(() => omdb.GetItemByTitle("star wars", 1500));
        }
        
        /// <summary>
        /// Games can't be requested by title. See #2
        /// </summary>
        [Fact]
        public void TestGetItemByTitleBad2()
        {
            var omdb = new OmdbClient(TestData.apikey, true);
            Assert.Throws<HttpRequestException>(() => omdb.GetItemByTitle("Skyrim", OmdbType.Game));
        }
        
        [Fact]
        public void TestGetItemByIdGood()
        {
            var omdb = new OmdbClient(TestData.apikey);
            var movie = omdb.GetItemById("tt0076759", true);
            
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
        public void TestGetItemByIdGood2()
        {
            var omdb = new OmdbClient(TestData.apikey, true);
            var game = omdb.GetItemById("tt1814884");
            
            Assert.Equal("The Elder Scrolls V: Skyrim", game.Title);
            Assert.Equal("2011", game.Year);
            Assert.Equal("N/A", game.Rated);
            Assert.Equal("11 Nov 2011", game.Released);
            Assert.Equal("N/A", game.Runtime);
        }

        [Fact]
        public void TestGetItemByIdBad()
        {
            var omdb = new OmdbClient(TestData.apikey);
            Assert.Throws<ArgumentException>(() => omdb.GetItemById(null));
            Assert.Throws<ArgumentException>(() => omdb.GetItemById(""));
            Assert.Throws<ArgumentException>(() => omdb.GetItemById(" "));
            
            Assert.Throws<HttpRequestException>(() => omdb.GetItemById("wrongID"));
        }
    }
}
