# OMDb-API.NET
[![NuGet](https://img.shields.io/nuget/v/OmdbApiNet.svg)](https://www.nuget.org/packages/OmdbApiNet/)

OMDb-API.NET is a .NET Standard 2.0 (C#) REST client for the [Open Movie Database API](http://www.omdbapi.com/), a web service to obtain movie information as found on IMDb.

## Installation ##
Choose a version on [nuget.org](https://www.nuget.org/packages/OmdbApiNet/) and use it for your project.

## Usage ##
There is a synchronous client `OmdbClient` and a asynchronous client `AsyncOmdbClient`. The asynchronous client provides the same methods as the synchronous one. The only differences are that you have to append `Async` to the method name and they will return Tasks, so that they are awaitable:
```cs
    Item item = await omdb.GetItemByTitleAsync("title");
```


### Create OMDb Client ###
```cs
    OmdbClient omdb = new OmdbClient("your_apikey");
    
    // enable ratings from Rotten Tomatoes
    OmdbClient omdb = new OmdbClient("your_apikey", true);
```
You can get an api key on the [OMDb website](http://www.omdbapi.com/).

### Get an Item (movie or series) ###
```cs
    // Item GetItemByTitle(string title, bool fullPlot = false);
    Item item = omdb.GetItemByTitle("title");
    Item item = omdb.GetItemByTitle("title", true);

    // Item GetItemByTitle(string title, OmdbType type, bool fullPlot = false);
    Item item = omdb.GetItemByTitle("title", OmdbType.Movie);
    Item item = omdb.GetItemByTitle("title", OmdbType.Series, true);
    
    // Item GetItemByTitle(string title, int? year, bool fullPlot = false);
    Item item = omdb.GetItemByTitle("title", 2017);
    Item item = omdb.GetItemByTitle("title", 2017, true);
    
    // Item GetItemByTitle(string title, OmdbType type, int? year, bool fullPlot = false);
    Item item = omdb.GetItemByTitle("title", OmdbType.Series, 2017);
    Item item = omdb.GetItemByTitle("title", OmdbType.Movie, 2017, true);

    // Item GetItemById(string id, bool fullPlot = false);
    Item item = omdb.GetItemById("imdb_id");
    Item item = omdb.GetItemById("imdb_id", true);
```
You can get the type of an item with `item.Type`. `item.Type` can either be `"movie"`, `"series"` or `"episode"`.
For getting an episode use `GetEpisodeBySeriesId()`, `GetEpisodeBySeriesTitle()` or `GetEpisodeByEpisodeId()` instead.

### Get an Episode ###
```cs
    // Episode GetEpisodeBySeriesId(string seriesId, int seasonNumber, int episodeNumber);
    Episode episode = omdb.GetEpisodeBySeriesId("imdb_series_id", 1, 1);
    
    // Episode GetEpisodeBySeriesTitle(string seriesTitle, int seasonNumber, int episodeNumber);
    Episode episode = omdb.GetEpisodeBySeriesTitle("imdb_series_title", 1, 1);
    
    // Episode GetEpisodeByEpisodeId(string episodeId);
    Episode episode = omdb.GetEpisodeByEpisodeId("imdb_id");
```

### Get a Season ###
```cs
    // Season GetSeasonBySeriesId(string seriesId, int seasonNumber);
    Season season = omdb.GetSeasonBySeriesId("imdb_series_id", 1);
    
    // Season GetSeasonBySeriesTitle(string seriesTitle, int seasonNumber);
    Season season = omdb.GetSeasonBySeriesTitle("imdb_series_title", 1);
```

### Get Search Results (movies and series) ###
```cs
    // SearchList GetSearchList(string query, int page = 1);
    SearchList searchList = omdb.GetSearchList("query");
    SearchList searchList = omdb.GetSearchList("query", 2);
    
    // SearchList GetSearchList(string query, OmdbType type, int page = 1);
    SearchList searchList = omdb.GetSearchList("query", OmdbType.Movie);
    SearchList searchList = omdb.GetSearchList("query", OmdbType.Series, 2);
    
    // SearchList GetSearchList(int? year, string query, int page = 1);
    SearchList searchList = omdb.GetSearchList(2017, "query");
    SearchList searchList = omdb.GetSearchList(2017, "query", 2);
    
    // SearchList GetSearchList(int? year, string query, OmdbType type, int page = 1);
    SearchList searchList = omdb.GetSearchList(2017, "query", OmdbType.Movie);
    SearchList searchList = omdb.GetSearchList(2017, "query", OmdbType.Series, 2);
```
The query can contain whitespaces.
