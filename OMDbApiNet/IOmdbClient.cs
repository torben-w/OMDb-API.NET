using OMDbApiNet.Model;

namespace OMDbApiNet
{
    public enum OmdbType
    {
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

        Episode GetEpisode(string seriesId, int seasonNumber, int episodeNumber);
        
        Season GetSeason(string seriesId, int seasonNumber);
        
        
    }
}
