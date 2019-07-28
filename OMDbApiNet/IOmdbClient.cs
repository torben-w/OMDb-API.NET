using OMDbApiNet.Model;

namespace OMDbApiNet
{
    public interface IOmdbClient
    {
        /// <summary>
        /// Get an Item by its title.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fullPlot"></param>
        /// <returns>Item</returns>
        Item GetItemByTitle(string title, bool fullPlot = false);
        
        /// <summary>
        /// Get an Item by its title.
        /// <br/><br/>
        /// Games (OmdbType.Game) can only be requested by Id, not by title. This is due to restrictions of the Open Movie Database API and can't be fixed on
        /// the client side.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// <param name="fullPlot"></param>
        /// <returns>Item</returns>
        Item GetItemByTitle(string title, OmdbType type, bool fullPlot = false);
        
        /// <summary>
        /// Get an Item by its title.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="year"></param>
        /// <param name="fullPlot"></param>
        /// <returns>Item</returns>
        Item GetItemByTitle(string title, int? year, bool fullPlot = false);
        
        /// <summary>
        /// Get an Item by its title.
        /// <br/><br/>
        /// Games (OmdbType.Game) can only be requested by Id, not by title. This is due to restrictions of the Open Movie Database API and can't be fixed on
        /// the client side.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// <param name="year"></param>
        /// <param name="fullPlot"></param>
        /// <returns>Item</returns>
        Item GetItemByTitle(string title, OmdbType type, int? year, bool fullPlot = false);

        /// <summary>
        /// Get an Item by its IMDb id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fullPlot"></param>
        /// <returns>Item</returns>
        Item GetItemById(string id, bool fullPlot = false);

        
        /// <summary>
        /// Get a list with search results for the given query.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <returns>SearchList</returns>
        SearchList GetSearchList(string query, int page = 1);
        
        /// <summary>
        /// Get a list with search results for the given query and type.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="type"></param>
        /// <param name="page"></param>
        /// <returns>SearchList</returns>
        SearchList GetSearchList(string query, OmdbType type, int page = 1);
        
        /// <summary>
        /// Get a list with search results for the given year and query.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <returns>SearchList</returns>
        SearchList GetSearchList(int? year, string query, int page = 1);
        
        /// <summary>
        /// Get a list with search results for the given year, query and type.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="query"></param>
        /// <param name="type"></param>
        /// <param name="page"></param>
        /// <returns>SearchList</returns>
        SearchList GetSearchList(int? year, string query, OmdbType type, int page = 1);

        
        /// <summary>
        /// Get an Episode by the IMDb id of the series, its season number and its episode number.
        /// </summary>
        /// <param name="seriesId"></param>
        /// <param name="seasonNumber"></param>
        /// <param name="episodeNumber"></param>
        /// <returns>Episode</returns>
        Episode GetEpisodeBySeriesId(string seriesId, int seasonNumber, int episodeNumber);
        
        /// <summary>
        /// Get an Episode by the name of the series, its season number and its episode number.
        /// </summary>
        /// <param name="seriesTitle"></param>
        /// <param name="seasonNumber"></param>
        /// <param name="episodeNumber"></param>
        /// <returns>Episode</returns>
        Episode GetEpisodeBySeriesTitle(string seriesTitle, int seasonNumber, int episodeNumber);
        
        /// <summary>
        /// Get an Episode by its IMDb id.
        /// </summary>
        /// <param name="episodeId"></param>
        /// <returns>Episode</returns>
        Episode GetEpisodeByEpisodeId(string episodeId);
        
        
        /// <summary>
        /// Get a Season by the IMDb id of the series and its season number.
        /// </summary>
        /// <param name="seriesId"></param>
        /// <param name="seasonNumber"></param>
        /// <returns>Season</returns>
        Season GetSeasonBySeriesId(string seriesId, int seasonNumber);
        
        /// <summary>
        /// Get a Season by the name of the series and its season number.
        /// </summary>
        /// <param name="seriesTitle"></param>
        /// <param name="seasonNumber"></param>
        /// <returns>Season</returns>
        Season GetSeasonBySeriesTitle(string seriesTitle, int seasonNumber);
    }
}
