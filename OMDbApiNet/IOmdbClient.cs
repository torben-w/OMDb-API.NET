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
        
        Item GetItemByTitle(string title, uint? year, bool fullPlot = false);
        
        Item GetItemByTitle(string title, OmdbType type, uint? year, bool fullPlot = false);

        Item GetItemById(string id, bool fullPlot = false);

        
        SearchList GetSearchList(string query, uint page = 1);
        
        SearchList GetSearchList(string query, OmdbType type, uint page = 1);
        
        SearchList GetSearchList(uint? year, string query, uint page = 1);
        
        SearchList GetSearchList(uint? year, string query, OmdbType type, uint page = 1);

        
        Episode GetEpisodeBySeriesId(string seriesId, uint seasonNumber, uint episodeNumber);
        
        Episode GetEpisodeBySeriesTitle(string seriesTitle, uint seasonNumber, uint episodeNumber);
        
        Episode GetEpisodeByEpisodeId(string episodeId);
        
        
        Season GetSeasonBySeriesId(string seriesId, uint seasonNumber);
        
        Season GetSeasonBySeriesTitle(string seriesTitle, uint seasonNumber);
    }
}
