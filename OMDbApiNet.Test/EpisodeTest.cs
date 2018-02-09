using System;
using System.Net.Http;
using Xunit;
using OMDbApiNet;

namespace TestOmdbApiNet
{
    /*
     * Data in these unit tests last checked on 02/09/2018 (American date format).
     */
    public class EpisodeTest
    {
        // TODO: Insert your api key here. You can get one on http://www.omdbapi.com/
        private readonly string apikey = "";
        
        [Fact]
        public void TestGetEpisodeBySeriesIdGood()
        {
            var omdb = new OmdbClient(apikey);
            var episode = omdb.GetEpisodeBySeriesId("tt2193021", 1, 1);


            var ratings = episode.Ratings.ToArray();
            Assert.Equal("Internet Movie Database", ratings[0].Source);
            Assert.Equal("8.5/10", ratings[0].Value);

            Assert.Equal("Pilot", episode.Title);
            Assert.Equal("2012", episode.Year);
            Assert.Equal("TV-PG", episode.Rated);
            Assert.Equal("10 Oct 2012", episode.Released);
            Assert.Equal("1", episode.SeasonNumber);
            Assert.Equal("1", episode.EpisodeNumber);
            Assert.Equal("45 min", episode.Runtime);
            Assert.Equal("Action, Adventure, Crime", episode.Genre);
            Assert.Equal("David Nutter", episode.Director);
            Assert.Equal("Greg Berlanti (developed by), Marc Guggenheim (developed by), Andrew Kreisberg (developed by), Andrew Kreisberg (teleplay by), Marc Guggenheim (teleplay by), Greg Berlanti (story by), Marc Guggenheim (story by)", episode.Writer);
            Assert.Equal("Stephen Amell, Katie Cassidy, Colin Donnell, David Ramsey", episode.Actors);
            Assert.Equal("Billionaire playboy, Oliver Queen, has been considered dead for five years. Now, he has returned. But something, during those five years, has changed him into a mysterious green hooded archer.", episode.Plot);
            Assert.Equal("English", episode.Language);
            Assert.Equal("USA, Canada", episode.Country);
            Assert.Equal("N/A", episode.Awards);
            Assert.Equal("https://images-na.ssl-images-amazon.com/images/M/MV5BMjE2MjY4MDE4Nl5BMl5BanBnXkFtZTcwNDA2NTk0OA@@._V1_SX300.jpg", episode.Poster);
            Assert.Equal("N/A", episode.Metascore);
            Assert.Equal("8.5", episode.ImdbRating);
            Assert.Equal("6184", episode.ImdbVotes);
            Assert.Equal("tt2340185", episode.ImdbId);
            Assert.Equal("tt2193021", episode.SeriesId);
            Assert.Equal("episode", episode.Type);
            Assert.Equal("True", episode.Response);
        }
        
        [Fact]
        public void TestGetEpisodeBySeriesIdBad()
        {
            var omdb = new OmdbClient(apikey);

            Assert.Throws<ArgumentException>(() => omdb.GetEpisodeBySeriesId(null, 1, 1));
            Assert.Throws<ArgumentException>(() => omdb.GetEpisodeBySeriesId("", 1, 1));
            Assert.Throws<ArgumentException>(() => omdb.GetEpisodeBySeriesId(" ", 1, 1));
            
            Assert.Throws<ArgumentOutOfRangeException>(() => omdb.GetEpisodeBySeriesId("tt2193021", 0, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => omdb.GetEpisodeBySeriesId("tt2193021", 1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => omdb.GetEpisodeBySeriesId("tt2193021", 0, 0));
            
            Assert.Throws<HttpRequestException>(() => omdb.GetEpisodeBySeriesId("asdf", 1, 1));
            Assert.Throws<HttpRequestException>(() => omdb.GetEpisodeBySeriesTitle("tt2193021", 100, 1));
            Assert.Throws<HttpRequestException>(() => omdb.GetEpisodeBySeriesTitle("tt2193021", 1, 100));
        }
        
        [Fact]
        public void TestGetEpisodeBySeriesTitleGood()
        {
            var omdb = new OmdbClient(apikey);
            var episode = omdb.GetEpisodeBySeriesTitle("arrow", 1, 1);


            var ratings = episode.Ratings.ToArray();
            Assert.Equal("Internet Movie Database", ratings[0].Source);
            Assert.Equal("8.5/10", ratings[0].Value);

            Assert.Equal("Pilot", episode.Title);
            Assert.Equal("2012", episode.Year);
            Assert.Equal("TV-PG", episode.Rated);
            Assert.Equal("10 Oct 2012", episode.Released);
            Assert.Equal("1", episode.SeasonNumber);
            Assert.Equal("1", episode.EpisodeNumber);
            Assert.Equal("45 min", episode.Runtime);
            Assert.Equal("Action, Adventure, Crime", episode.Genre);
            Assert.Equal("David Nutter", episode.Director);
            Assert.Equal("Greg Berlanti (developed by), Marc Guggenheim (developed by), Andrew Kreisberg (developed by), Andrew Kreisberg (teleplay by), Marc Guggenheim (teleplay by), Greg Berlanti (story by), Marc Guggenheim (story by)", episode.Writer);
            Assert.Equal("Stephen Amell, Katie Cassidy, Colin Donnell, David Ramsey", episode.Actors);
            Assert.Equal("Billionaire playboy, Oliver Queen, has been considered dead for five years. Now, he has returned. But something, during those five years, has changed him into a mysterious green hooded archer.", episode.Plot);
            Assert.Equal("English", episode.Language);
            Assert.Equal("USA, Canada", episode.Country);
            Assert.Equal("N/A", episode.Awards);
            Assert.Equal("https://images-na.ssl-images-amazon.com/images/M/MV5BMjE2MjY4MDE4Nl5BMl5BanBnXkFtZTcwNDA2NTk0OA@@._V1_SX300.jpg", episode.Poster);
            Assert.Equal("N/A", episode.Metascore);
            Assert.Equal("8.5", episode.ImdbRating);
            Assert.Equal("6184", episode.ImdbVotes);
            Assert.Equal("tt2340185", episode.ImdbId);
            Assert.Equal("tt2193021", episode.SeriesId);
            Assert.Equal("episode", episode.Type);
            Assert.Equal("True", episode.Response);
        }
        
        [Fact]
        public void TestGetEpisodeBySeriesTitleBad()
        {
            var omdb = new OmdbClient(apikey);

            Assert.Throws<ArgumentException>(() => omdb.GetEpisodeBySeriesTitle(null, 1, 1));
            Assert.Throws<ArgumentException>(() => omdb.GetEpisodeBySeriesTitle("", 1, 1));
            Assert.Throws<ArgumentException>(() => omdb.GetEpisodeBySeriesTitle(" ", 1, 1));
            
            Assert.Throws<ArgumentOutOfRangeException>(() => omdb.GetEpisodeBySeriesTitle("arrow", 0, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => omdb.GetEpisodeBySeriesTitle("arrow", 1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => omdb.GetEpisodeBySeriesTitle("arrow", 0, 0));
            
            Assert.Throws<HttpRequestException>(() => omdb.GetEpisodeBySeriesTitle("asdf", 1, 1));
            Assert.Throws<HttpRequestException>(() => omdb.GetEpisodeBySeriesTitle("arrow", 100, 1));
            Assert.Throws<HttpRequestException>(() => omdb.GetEpisodeBySeriesTitle("arrow", 1, 100));
        }
        
        [Fact]
        public void TestGetEpisodeByEpisodeIdGood()
        {
            var omdb = new OmdbClient(apikey);
            var episode = omdb.GetEpisodeByEpisodeId("tt2340185");


            var ratings = episode.Ratings.ToArray();
            Assert.Equal("Internet Movie Database", ratings[0].Source);
            Assert.Equal("8.5/10", ratings[0].Value);

            Assert.Equal("Pilot", episode.Title);
            Assert.Equal("2012", episode.Year);
            Assert.Equal("TV-PG", episode.Rated);
            Assert.Equal("10 Oct 2012", episode.Released);
            Assert.Equal("1", episode.SeasonNumber);
            Assert.Equal("1", episode.EpisodeNumber);
            Assert.Equal("45 min", episode.Runtime);
            Assert.Equal("Action, Adventure, Crime", episode.Genre);
            Assert.Equal("David Nutter", episode.Director);
            Assert.Equal("Greg Berlanti (developed by), Marc Guggenheim (developed by), Andrew Kreisberg (developed by), Andrew Kreisberg (teleplay by), Marc Guggenheim (teleplay by), Greg Berlanti (story by), Marc Guggenheim (story by)", episode.Writer);
            Assert.Equal("Stephen Amell, Katie Cassidy, Colin Donnell, David Ramsey", episode.Actors);
            Assert.Equal("Billionaire playboy, Oliver Queen, has been considered dead for five years. Now, he has returned. But something, during those five years, has changed him into a mysterious green hooded archer.", episode.Plot);
            Assert.Equal("English", episode.Language);
            Assert.Equal("USA, Canada", episode.Country);
            Assert.Equal("N/A", episode.Awards);
            Assert.Equal("https://images-na.ssl-images-amazon.com/images/M/MV5BMjE2MjY4MDE4Nl5BMl5BanBnXkFtZTcwNDA2NTk0OA@@._V1_SX300.jpg", episode.Poster);
            Assert.Equal("N/A", episode.Metascore);
            Assert.Equal("8.5", episode.ImdbRating);
            Assert.Equal("6184", episode.ImdbVotes);
            Assert.Equal("tt2340185", episode.ImdbId);
            Assert.Equal("tt2193021", episode.SeriesId);
            Assert.Equal("episode", episode.Type);
            Assert.Equal("True", episode.Response);
        }
        
        [Fact]
        public void TestGetEpisodeByEpisodeIdBad()
        {
            var omdb = new OmdbClient(apikey);

            Assert.Throws<ArgumentException>(() => omdb.GetEpisodeByEpisodeId(null));
            Assert.Throws<ArgumentException>(() => omdb.GetEpisodeByEpisodeId(""));
            Assert.Throws<ArgumentException>(() => omdb.GetEpisodeByEpisodeId(" "));

            Assert.Throws<HttpRequestException>(() => omdb.GetEpisodeByEpisodeId("asdf"));
        }

    }
}
