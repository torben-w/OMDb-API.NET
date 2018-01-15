# OMDb-API.NET
OMDb-API.NET is a .NET Standard 2.0 API for the [Open Movie Database](http://www.omdbapi.com/), 
a webservice to obtain movie information as found on IMDb. 

## Usage ##

### Create OMDb Client ###
```cs
    var omdb = new OmdbClient("your_apikey");
    
    // enable ratings from Rotten Tomatoes
    var omdb = new OmdbClient("your_apikey", true);
```
You can get an api key on the [OMDb website](http://www.omdbapi.com/).

### Get an Item (movie or series) ###
```cs
    // Item GetItemByTitle(string title, bool fullPlot = false);
    var item = omdb.GetItemByTitle("title");
    var item = omdb.GetItemByTitle("title", true);

    // Item GetItemByTitle(string title, OmdbType type, bool fullPlot = false);
    var item = omdb.GetItemByTitle("title", OmdbType.Movie);
    var item = omdb.GetItemByTitle("title", OmdbType.Series, true);
    
    // Item GetItemByTitle(string title, uint? year, bool fullPlot = false);
    var item = omdb.GetItemByTitle("title", 2017);
    var item = omdb.GetItemByTitle("title", 2017, true);
    
    // Item GetItemByTitle(string title, OmdbType type, uint? year, bool fullPlot = false);
    var item = omdb.GetItemByTitle("title", OmdbType.Series, 2017);
    var item = omdb.GetItemByTitle("title", OmdbType.Movie, 2017, true);

    // Item GetItemById(string id, bool fullPlot = false);
    var item = omdb.GetItemByOd("imdb_id");
    var item = omdb.GetItemByOd("imdb_id", true);
```
You can get the type of an item with `item.Type`. `item.Type` can either be `"movie"`, `"series"` or `"episode"`. 
For getting an episode use `GetEpisodeBySeriesId()`, `GetEpisodeBySeriesTitle()` or `GetEpisodeByEpisodeId()` instead.

### Get an Episode ###
```cs
    // Episode GetEpisodeBySeriesId(string seriesId, uint seasonNumber, uint episodeNumber);
    var episode = omdb.GetEpisodeBySeriesId("imdb_series_id", 1, 1);
    
    // Episode GetEpisodeBySeriesTitle(string seriesTitle, uint seasonNumber, uint episodeNumber);
    var episode = omdb.GetEpisodeBySeriesTitle("imdb_series_title", 1, 1);
    
    // Episode GetEpisodeByEpisodeId(string episodeId);
    var episode = omdb.GetEpisodeByEpisodeId("imdb_id");
```

### Get a Season ###
```cs
    // Season GetSeasonBySeriesId(string seriesId, uint seasonNumber);
    var season = omdb.GetSeasonBySeriesId("imdb_series_id", 1);
    
    // Season GetSeasonBySeriesTitle(string seriesTitle, uint seasonNumber);
    var season = omdb.GetSeasonBySeriesTitle("imdb_series_title", 1);
```

### Get Search Results (movies and series) ###
```cs
    // SearchList GetSearchList(string query, uint page = 1);
    var searchList = omdb.GetSearchList("query");
    var searchList = omdb.GetSearchList("query", 2);
    
    // SearchList GetSearchList(string query, OmdbType type, uint page = 1);
    var searchList = omdb.GetSearchList("query", OmdbType.Movie);
    var searchList = omdb.GetSearchList("query", OmdbType.Series, 2);
    
    // SearchList GetSearchList(uint? year, string query, uint page = 1);
    var searchList = omdb.GetSearchList(2017, "query");
    var searchList = omdb.GetSearchList(2017, "query", 2);
    
    // SearchList GetSearchList(uint? year, string query, OmdbType type, uint page = 1);
    var searchList = omdb.GetSearchList(2017, "query", OmdbType.Movie);
    var searchList = omdb.GetSearchList(2017, "query", OmdbType.Series, 2);
```
The query can contain whitespaces. 
