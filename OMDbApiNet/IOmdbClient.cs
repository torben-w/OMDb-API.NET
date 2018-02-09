using OMDbApiNet.Model;

namespace OMDbApiNet
{
    public enum OmdbType
    {
        None,
        Movie,
        Series
    }
    
    public interface IOmdbClient
    {
        Item GetItemByTitle(string title, bool fullPlot = false);
        
        Item GetItemByTitle(string title, OmdbType type, bool fullPlot = false);
        
        Item GetItemByTitle(string title, int? year, bool fullPlot = false);
        
        Item GetItemByTitle(string title, OmdbType type, int? year, bool fullPlot = false);

        Item GetItemById(string id, bool fullPlot = false);

        
        SearchList GetSearchList(string query, int page = 1);
        
        SearchList GetSearchList(string query, OmdbType type, int page = 1);
        
        SearchList GetSearchList(int? year, string query, int page = 1);
        
        SearchList GetSearchList(int? year, string query, OmdbType type, int page = 1);

        
        Episode GetEpisodeBySeriesId(string seriesId, int seasonNumber, int episodeNumber);
        
        Episode GetEpisodeBySeriesTitle(string seriesTitle, int seasonNumber, int episodeNumber);
        
        Episode GetEpisodeByEpisodeId(string episodeId);
        
        
        Season GetSeasonBySeriesId(string seriesId, int seasonNumber);
        
        Season GetSeasonBySeriesTitle(string seriesTitle, int seasonNumber);
    }
}
