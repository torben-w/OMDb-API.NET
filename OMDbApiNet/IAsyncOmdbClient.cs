using System.Threading.Tasks;
using OMDbApiNet.Model;

namespace OMDbApiNet
{
	public interface IAsyncOmdbClient
	{
		/// <summary>
		/// Get an Item by its title asynchronously.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="fullPlot"></param>
		/// <returns>Item</returns>
		Task<Item> GetItemByTitleAsync(string title, bool fullPlot = false);
        
		/// <summary>
		/// Get an Item by its title asynchronously.
		/// <br/><br/>
		/// Games (OmdbType.Game) can only be requested by Id, not by title. This is due to restrictions of the Open Movie Database API and can't be fixed on
		/// the client side.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="type"></param>
		/// <param name="fullPlot"></param>
		/// <returns>Item</returns>
		Task<Item> GetItemByTitleAsync(string title, OmdbType type, bool fullPlot = false);
        
		/// <summary>
		/// Get an Item by its title asynchronously.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="year"></param>
		/// <param name="fullPlot"></param>
		/// <returns>Item</returns>
		Task<Item> GetItemByTitleAsync(string title, int? year, bool fullPlot = false);
        
		/// <summary>
		/// Get an Item by its title asynchronously.
		/// <br/><br/>
		/// Games (OmdbType.Game) can only be requested by Id, not by title. This is due to restrictions of the Open Movie Database API and can't be fixed on
		/// the client side.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="type"></param>
		/// <param name="year"></param>
		/// <param name="fullPlot"></param>
		/// <returns>Item</returns>
		Task<Item> GetItemByTitleAsync(string title, OmdbType type, int? year, bool fullPlot = false);

		/// <summary>
		/// Get an Item by its IMDb id asynchronously.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="fullPlot"></param>
		/// <returns>Item</returns>
		Task<Item> GetItemByIdAsync(string id, bool fullPlot = false);

        
		/// <summary>
		/// Get a list with search results for the given query asynchronously.
		/// </summary>
		/// <param name="query"></param>
		/// <param name="page"></param>
		/// <returns>SearchList</returns>
		Task<SearchList> GetSearchListAsync(string query, int page = 1);
        
		/// <summary>
		/// Get a list with search results for the given query and type asynchronously.
		/// </summary>
		/// <param name="query"></param>
		/// <param name="type"></param>
		/// <param name="page"></param>
		/// <returns>SearchList</returns>
		Task<SearchList> GetSearchListAsync(string query, OmdbType type, int page = 1);
        
		/// <summary>
		/// Get a list with search results for the given year and query asynchronously.
		/// </summary>
		/// <param name="year"></param>
		/// <param name="query"></param>
		/// <param name="page"></param>
		/// <returns>SearchList</returns>
		Task<SearchList> GetSearchListAsync(int? year, string query, int page = 1);
        
		/// <summary>
		/// Get a list with search results for the given year, query and type asynchronously.
		/// </summary>
		/// <param name="year"></param>
		/// <param name="query"></param>
		/// <param name="type"></param>
		/// <param name="page"></param>
		Task<SearchList> GetSearchListAsync(int? year, string query, OmdbType type, int page = 1);

        
		/// <summary>
		/// Get an Episode by the IMDb id of the series, its season number and its episode number asynchronously.
		/// </summary>
		/// <param name="seriesId"></param>
		/// <param name="seasonNumber"></param>
		/// <param name="episodeNumber"></param>
		/// <returns>Episode</returns>
		Task<Episode> GetEpisodeBySeriesIdAsync(string seriesId, int seasonNumber, int episodeNumber);
        
		/// <summary>
		/// Get an Episode by the name of the series, its season number and its episode number asynchronously.
		/// </summary>
		/// <param name="seriesTitle"></param>
		/// <param name="seasonNumber"></param>
		/// <param name="episodeNumber"></param>
		/// <returns>Episode</returns>
		Task<Episode> GetEpisodeBySeriesTitleAsync(string seriesTitle, int seasonNumber, int episodeNumber);
        
		/// <summary>
		/// Get an Episode by its IMDb id asynchronously.
		/// </summary>
		/// <param name="episodeId"></param>
		/// <returns>Episode</returns>
		Task<Episode> GetEpisodeByEpisodeIdAsync(string episodeId);
        
        
		/// <summary>
		/// Get a Season by the IMDb id of the series and its season number asynchronously.
		/// </summary>
		/// <param name="seriesId"></param>
		/// <param name="seasonNumber"></param>
		/// <returns>Season</returns>
		Task<Season> GetSeasonBySeriesIdAsync(string seriesId, int seasonNumber);
        
		/// <summary>
		/// Get a Season by the name of the series and its season number asynchronously.
		/// </summary>
		/// <param name="seriesTitle"></param>
		/// <param name="seasonNumber"></param>
		/// <returns>Season</returns>
		Task<Season> GetSeasonBySeriesTitleAsync(string seriesTitle, int seasonNumber);
	}
}
