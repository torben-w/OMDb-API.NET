using System.Threading.Tasks;
using OMDbApiNet.Model;

namespace OMDbApiNet
{
	public interface IAsyncOmdbClient
	{
		Task<Item> GetItemByTitleAsync(string title, bool fullPlot = false);
        
		Task<Item> GetItemByTitleAsync(string title, OmdbType type, bool fullPlot = false);
        
		Task<Item> GetItemByTitleAsync(string title, int? year, bool fullPlot = false);
        
		Task<Item> GetItemByTitleAsync(string title, OmdbType type, int? year, bool fullPlot = false);

		Task<Item> GetItemByIdAsync(string id, bool fullPlot = false);

        
		Task<SearchList> GetSearchListAsync(string query, int page = 1);
        
		Task<SearchList> GetSearchListAsync(string query, OmdbType type, int page = 1);
        
		Task<SearchList> GetSearchListAsync(int? year, string query, int page = 1);
        
		Task<SearchList> GetSearchListAsync(int? year, string query, OmdbType type, int page = 1);

        
		Task<Episode> GetEpisodeBySeriesIdAsync(string seriesId, int seasonNumber, int episodeNumber);
        
		Task<Episode> GetEpisodeBySeriesTitleAsync(string seriesTitle, int seasonNumber, int episodeNumber);
        
		Task<Episode> GetEpisodeByEpisodeIdAsync(string episodeId);
        
        
		Task<Season> GetSeasonBySeriesIdAsync(string seriesId, int seasonNumber);
        
		Task<Season> GetSeasonBySeriesTitleAsync(string seriesTitle, int seasonNumber);
	}
}
