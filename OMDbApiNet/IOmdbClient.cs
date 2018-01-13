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

        Episode GetEpisode(string seriesId, uint seasonNumber, uint episodeNumber);
        
        Season GetSeason(string seriesId, uint seasonNumber);
    }
}
