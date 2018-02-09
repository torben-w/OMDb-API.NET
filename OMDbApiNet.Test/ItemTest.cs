using System;
using System.Net.Http;
using Xunit;
using OMDbApiNet;

namespace TestOmdbApiNet
{
    /*
     * Data in these unit tests last checked on 02/09/2018 (American date format).
     */
    public class ItemTest
    {
        // TODO: Insert your api key here. You can get one on http://www.omdbapi.com/
        private readonly string apikey = "";
        
        [Fact]
        public void TestGetItemByTitleGood1()
        {
            var omdb = new OmdbClient(apikey);
            var movie = omdb.GetItemByTitle("Star Wars", true);
            
            var ratings = movie.Ratings.ToArray();
            Assert.Equal("Internet Movie Database", ratings[0].Source);
            Assert.Equal("8.7/10", ratings[0].Value);
            Assert.Equal("Rotten Tomatoes", ratings[1].Source);
            Assert.Equal("93%", ratings[1].Value);
            Assert.Equal("Metacritic", ratings[2].Source);
            Assert.Equal("90/100", ratings[2].Value);
            
            Assert.Equal("Star Wars: Episode IV - A New Hope", movie.Title);
            Assert.Equal("1977", movie.Year);
            Assert.Equal("PG", movie.Rated);
            Assert.Equal("25 May 1977", movie.Released);
            Assert.Equal("121 min", movie.Runtime);
            Assert.Equal("Action, Adventure, Fantasy", movie.Genre);
            Assert.Equal("George Lucas", movie.Director);
            Assert.Equal("George Lucas", movie.Writer);
            Assert.Equal("Mark Hamill, Harrison Ford, Carrie Fisher, Peter Cushing", movie.Actors);
            Assert.Equal("The Imperial Forces, under orders from cruel Darth Vader, hold Princess Leia hostage in their efforts to quell the rebellion against the Galactic Empire. Luke Skywalker and Han Solo, captain of the Millennium Falcon, work together with the companionable droid duo R2-D2 and C-3PO to rescue the beautiful princess, help the Rebel Alliance and restore freedom and justice to the Galaxy.", movie.Plot);
            Assert.Equal("English", movie.Language);
            Assert.Equal("USA", movie.Country);
            Assert.Equal("Won 6 Oscars. Another 50 wins & 28 nominations.", movie.Awards);
            Assert.Equal("https://images-na.ssl-images-amazon.com/images/M/MV5BNzVlY2MwMjktM2E4OS00Y2Y3LWE3ZjctYzhkZGM3YzA1ZWM2XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", movie.Poster);
            Assert.Equal("90", movie.Metascore);
            Assert.Equal("8.7", movie.ImdbRating);
            Assert.Equal("1,029,576", movie.ImdbVotes);
            Assert.Equal("tt0076759", movie.ImdbId);
            Assert.Equal("movie", movie.Type);
            Assert.Equal("21 Sep 2004", movie.Dvd);
            Assert.Equal("N/A", movie.BoxOffice);
            Assert.Equal("20th Century Fox", movie.Production);
            Assert.Equal("http://www.starwars.com/episode-iv/", movie.Website);
            Assert.Equal(null, movie.TotalSeasons);
            Assert.Equal("True", movie.Response);
        }
        
        [Fact]
        public void TestGetItemByTitleGood2()
        {
            var omdb = new OmdbClient(apikey, true);
            var movie = omdb.GetItemByTitle("Star Wars", OmdbType.Movie, 2017, false);
            
            var ratings = movie.Ratings.ToArray();
            Assert.Equal("Internet Movie Database", ratings[0].Source);
            Assert.Equal("7.5/10", ratings[0].Value);
            Assert.Equal("Rotten Tomatoes", ratings[1].Source);
            Assert.Equal("90%", ratings[1].Value);
            Assert.Equal("Metacritic", ratings[2].Source);
            Assert.Equal("85/100", ratings[2].Value);
            
            Assert.Equal("Star Wars: The Last Jedi", movie.Title);
            Assert.Equal("2017", movie.Year);
            Assert.Equal("PG-13", movie.Rated);
            Assert.Equal("15 Dec 2017", movie.Released);
            Assert.Equal("152 min", movie.Runtime);
            Assert.Equal("Action, Adventure, Fantasy", movie.Genre);
            Assert.Equal("Rian Johnson", movie.Director);
            Assert.Equal("Rian Johnson, George Lucas (based on characters created by)", movie.Writer);
            Assert.Equal("Mark Hamill, Carrie Fisher, Adam Driver, Daisy Ridley", movie.Actors);
            Assert.Equal("Rey develops her newly discovered abilities with the guidance of Luke Skywalker, who is unsettled by the strength of her powers. Meanwhile, the Resistance prepares for battle with the First Order.", movie.Plot);
            Assert.Equal("English", movie.Language);
            Assert.Equal("USA", movie.Country);
            Assert.Equal("Nominated for 2 BAFTA Film Awards. Another 2 wins & 14 nominations.", movie.Awards);
            Assert.Equal("https://images-na.ssl-images-amazon.com/images/M/MV5BMjQ1MzcxNjg4N15BMl5BanBnXkFtZTgwNzgwMjY4MzI@._V1_SX300.jpg", movie.Poster);
            Assert.Equal("85", movie.Metascore);
            Assert.Equal("7.5", movie.ImdbRating);
            Assert.Equal("288,267", movie.ImdbVotes);
            Assert.Equal("tt2527336", movie.ImdbId);
            Assert.Equal("movie", movie.Type);
            Assert.Equal("N/A", movie.TomatoMeter);
            Assert.Equal("N/A", movie.TomatoImage);
            Assert.Equal("N/A", movie.TomatoRating);
            Assert.Equal("N/A", movie.TomatoReviews);
            Assert.Equal("N/A", movie.TomatoFresh);
            Assert.Equal("N/A", movie.TomatoRotten);
            Assert.Equal("N/A", movie.TomatoConsensus);
            Assert.Equal("N/A", movie.TomatoUserMeter);
            Assert.Equal("N/A", movie.TomatoUserRating);
            Assert.Equal("N/A", movie.TomatoUserReviews);
            Assert.Equal("http://www.rottentomatoes.com/m/star_wars_episode_viii/", movie.TomatoUrl);
            Assert.Equal("N/A", movie.Dvd);
            Assert.Equal("$572,691,546", movie.BoxOffice);
            Assert.Equal("Walt Disney Pictures", movie.Production);
            Assert.Equal("http://www.starwars.com/the-last-jedi/", movie.Website);
            Assert.Equal(null, movie.TotalSeasons);
            Assert.Equal("True", movie.Response);
        }
        
        [Fact]
        public void TestGetItemByTitleGood3()
        {
            var omdb = new OmdbClient(apikey, true);
            var movie = omdb.GetItemByTitle("Arrow", OmdbType.Series, 2012, false);
            
            var ratings = movie.Ratings.ToArray();
            Assert.Equal("Internet Movie Database", ratings[0].Source);
            Assert.Equal("7.8/10", ratings[0].Value);
            
            Assert.Equal("Arrow", movie.Title);
            Assert.Equal("2012–", movie.Year);
            Assert.Equal("TV-14", movie.Rated);
            Assert.Equal("10 Oct 2012", movie.Released);
            Assert.Equal("42 min", movie.Runtime);
            Assert.Equal("Action, Adventure, Crime", movie.Genre);
            Assert.Equal("N/A", movie.Director);
            Assert.Equal("Greg Berlanti, Marc Guggenheim, Andrew Kreisberg", movie.Writer);
            Assert.Equal("Stephen Amell, David Ramsey, Willa Holland, Paul Blackthorne", movie.Actors);
            Assert.Equal("Spoiled billionaire playboy Oliver Queen is missing and presumed dead when his yacht is lost at sea. He returns five years later a changed man, determined to clean up the city as a hooded vigilante armed with a bow.", movie.Plot);
            Assert.Equal("English", movie.Language);
            Assert.Equal("USA", movie.Country);
            Assert.Equal("11 wins & 42 nominations.", movie.Awards);
            Assert.Equal("https://images-na.ssl-images-amazon.com/images/M/MV5BMTUwOTgyNTQ1M15BMl5BanBnXkFtZTgwNDEyNzM3MzI@._V1_SX300.jpg", movie.Poster);
            Assert.Equal("N/A", movie.Metascore);
            Assert.Equal("7.8", movie.ImdbRating);
            Assert.Equal("348,615", movie.ImdbVotes);
            Assert.Equal("tt2193021", movie.ImdbId);
            Assert.Equal("series", movie.Type);
            Assert.Equal("N/A", movie.TomatoMeter);
            Assert.Equal("N/A", movie.TomatoImage);
            Assert.Equal("N/A", movie.TomatoRating);
            Assert.Equal("N/A", movie.TomatoReviews);
            Assert.Equal("N/A", movie.TomatoFresh);
            Assert.Equal("N/A", movie.TomatoRotten);
            Assert.Equal("N/A", movie.TomatoConsensus);
            Assert.Equal("N/A", movie.TomatoUserMeter);
            Assert.Equal("N/A", movie.TomatoUserRating);
            Assert.Equal("N/A", movie.TomatoUserReviews);
            Assert.Equal("N/A", movie.TomatoUrl);
            Assert.Equal("N/A", movie.Dvd);
            Assert.Equal("N/A", movie.BoxOffice);
            Assert.Equal("N/A", movie.Production);
            Assert.Equal("N/A", movie.Website);
            Assert.Equal("6", movie.TotalSeasons);
            Assert.Equal("True", movie.Response);
        }
        
        [Fact]
        public void TestGetItemByTitleBad()
        {
            var omdb = new OmdbClient(apikey, true);
            Assert.Throws<ArgumentException>(() => omdb.GetItemByTitle(null));
            Assert.Throws<ArgumentException>(() => omdb.GetItemByTitle(""));
            Assert.Throws<ArgumentException>(() => omdb.GetItemByTitle(" "));
            Assert.Throws<ArgumentOutOfRangeException>(() => omdb.GetItemByTitle("star wars", 1500));
        }
        
        [Fact]
        public void TestGetItemByIdGood()
        {
            var omdb = new OmdbClient(apikey);
            var movie = omdb.GetItemById("tt0076759", true);
            
            var ratings = movie.Ratings.ToArray();
            Assert.Equal("Internet Movie Database", ratings[0].Source);
            Assert.Equal("8.7/10", ratings[0].Value);
            Assert.Equal("Rotten Tomatoes", ratings[1].Source);
            Assert.Equal("93%", ratings[1].Value);
            Assert.Equal("Metacritic", ratings[2].Source);
            Assert.Equal("90/100", ratings[2].Value);
            
            Assert.Equal("Star Wars: Episode IV - A New Hope", movie.Title);
            Assert.Equal("1977", movie.Year);
            Assert.Equal("PG", movie.Rated);
            Assert.Equal("25 May 1977", movie.Released);
            Assert.Equal("121 min", movie.Runtime);
            Assert.Equal("Action, Adventure, Fantasy", movie.Genre);
            Assert.Equal("George Lucas", movie.Director);
            Assert.Equal("George Lucas", movie.Writer);
            Assert.Equal("Mark Hamill, Harrison Ford, Carrie Fisher, Peter Cushing", movie.Actors);
            Assert.Equal("The Imperial Forces, under orders from cruel Darth Vader, hold Princess Leia hostage in their efforts to quell the rebellion against the Galactic Empire. Luke Skywalker and Han Solo, captain of the Millennium Falcon, work together with the companionable droid duo R2-D2 and C-3PO to rescue the beautiful princess, help the Rebel Alliance and restore freedom and justice to the Galaxy.", movie.Plot);
            Assert.Equal("English", movie.Language);
            Assert.Equal("USA", movie.Country);
            Assert.Equal("Won 6 Oscars. Another 50 wins & 28 nominations.", movie.Awards);
            Assert.Equal("https://images-na.ssl-images-amazon.com/images/M/MV5BNzVlY2MwMjktM2E4OS00Y2Y3LWE3ZjctYzhkZGM3YzA1ZWM2XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", movie.Poster);
            Assert.Equal("90", movie.Metascore);
            Assert.Equal("8.7", movie.ImdbRating);
            Assert.Equal("1,029,576", movie.ImdbVotes);
            Assert.Equal("tt0076759", movie.ImdbId);
            Assert.Equal("movie", movie.Type);
            Assert.Equal("21 Sep 2004", movie.Dvd);
            Assert.Equal("N/A", movie.BoxOffice);
            Assert.Equal("20th Century Fox", movie.Production);
            Assert.Equal("http://www.starwars.com/episode-iv/", movie.Website);
            Assert.Equal("True", movie.Response);
        }

        [Fact]
        public void TestGetItemByIdBad()
        {
            var omdb = new OmdbClient(apikey);
            Assert.Throws<ArgumentException>(() => omdb.GetItemById(null));
            Assert.Throws<ArgumentException>(() => omdb.GetItemById(""));
            Assert.Throws<ArgumentException>(() => omdb.GetItemById(" "));
            
            Assert.Throws<HttpRequestException>(() => omdb.GetItemById("wrongID"));
        }
        
        

    }
}
