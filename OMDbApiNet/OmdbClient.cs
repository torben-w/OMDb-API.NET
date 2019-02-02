using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OMDbApiNet.Model;
using OMDbApiNet.Utilities;

namespace OMDbApiNet
{
    public class OmdbClient : IOmdbClient
    {
        private const string BaseUrl = "http://www.omdbapi.com/?";
        private readonly string _apikey;
        private readonly bool _rottenTomatoesRatings;
        
        public OmdbClient(string apikey, bool rottenTomatoesRatings = false)
        {
            _apikey = apikey;
            _rottenTomatoesRatings = rottenTomatoesRatings;
        }

        #region ApiImplementation

        public Item GetItemByTitle(string title, bool fullPlot = false)
        {
            return GetItemByTitle(title, OmdbType.None, null, fullPlot);
        }

        public Item GetItemByTitle(string title, OmdbType type, bool fullPlot = false)
        {
            return GetItemByTitle(title, type, null, fullPlot);
        }

        public Item GetItemByTitle(string title, int? year, bool fullPlot = false)
        {
            return GetItemByTitle(title, OmdbType.None, year, fullPlot);
        }

        public Item GetItemByTitle(string title, OmdbType type, int? year, bool fullPlot = false)
        {
            var query = QueryBuilder.GetItemByTitleQuery(title, type, year, fullPlot);

            var item = GetOmdbDataAsync<Item>(query).Result;

            if (item.Response.Equals("False"))
            {
                throw new HttpRequestException(item.Error);
            }
            
            return item;
        }

        public Item GetItemById(string id, bool fullPlot = false)
        {
            var query = QueryBuilder.GetItemByIdQuery(id, fullPlot);
            
            var item = GetOmdbDataAsync<Item>(query).Result;
            
            if (item.Response.Equals("False"))
            {
                throw new HttpRequestException(item.Error);
            }
            
            return item;
        }

        public SearchList GetSearchList(string query, int page = 1)
        {
            return GetSearchList(null, query, OmdbType.None, page);
        }
        
        public SearchList GetSearchList(string query, OmdbType type, int page = 1)
        {
            return GetSearchList(null, query, type, page);
        }

        public SearchList GetSearchList(int? year, string query, int page = 1)
        {
            return GetSearchList(year, query, OmdbType.None, page);
        }

        public SearchList GetSearchList(int? year, string query, OmdbType type, int page = 1)
        {
            var editedQuery = QueryBuilder.GetSearchListQuery(year, query, type, page);

            var searchList = GetOmdbDataAsync<SearchList>(editedQuery).Result;
            
            if (searchList.Response.Equals("False"))
            {
                throw new HttpRequestException(searchList.Error);
            }
            
            return searchList;
        }

        public Episode GetEpisodeBySeriesId(string seriesId, int seasonNumber, int episodeNumber)
        {
            if (string.IsNullOrWhiteSpace(seriesId))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(seriesId));
            }

            return GetEpisode(seriesId, null, seasonNumber, episodeNumber);
        }

        public Episode GetEpisodeBySeriesTitle(string seriesTitle, int seasonNumber, int episodeNumber)
        {
            if (string.IsNullOrWhiteSpace(seriesTitle))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(seriesTitle));
            }

            return GetEpisode(null, seriesTitle, seasonNumber, episodeNumber);
        }

        public Episode GetEpisodeByEpisodeId(string episodeId)
        {
            var query = QueryBuilder.GetEpisodeByEpisodeIdQuery(episodeId);
            
            var episode = GetOmdbDataAsync<Episode>(query).Result;
            
            if (episode.Response.Equals("False"))
            {
                throw new HttpRequestException(episode.Error);
            }
            
            return episode;
        }

        public Season GetSeasonBySeriesId(string seriesId, int seasonNumber)
        {
            if (string.IsNullOrWhiteSpace(seriesId))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(seriesId));
            }

            return GetSeason(seriesId, null, seasonNumber);
        }
        
        public Season GetSeasonBySeriesTitle(string seriesTitle, int seasonNumber)
        {
            if (string.IsNullOrWhiteSpace(seriesTitle))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(seriesTitle));
            }

            return GetSeason(null, seriesTitle, seasonNumber);
        }

        #endregion
        
        #region Internal

        private async Task<T> GetOmdbDataAsync<T>(string query)
        {
            using (var client = new HttpClient {BaseAddress = new Uri(BaseUrl)})
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client
                    .GetAsync($"{BaseUrl}apikey={_apikey}{query}&tomatoes={_rottenTomatoesRatings}")
                    .ConfigureAwait(false);
            
                if (!response.IsSuccessStatusCode)
                {
                    return default(T);
                }
            
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
                {
                    MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                    DateParseHandling = DateParseHandling.None,
                    Error = delegate(object sender, ErrorEventArgs args) 
                    { 
                        var currentError = args.ErrorContext.Error.Message;
                        args.ErrorContext.Handled = true;
                    }
                });
            }
        }
        
        private Episode GetEpisode(string seriesId, string seriesTitle, int seasonNumber, int episodeNumber)
        {
            if (seasonNumber <= 0)
            {
                throw new ArgumentOutOfRangeException("Season number has to be greater than zero.", nameof(seasonNumber));
            }
            if (episodeNumber <= 0)
            {
                throw new ArgumentOutOfRangeException("Episode number has to be greater than zero.", nameof(episodeNumber));
            }

            var query = GetSeasonEpisodeQuery(seriesId, seriesTitle, seasonNumber, episodeNumber);
            
            var episode = GetOmdbDataAsync<Episode>(query).Result;
            
            if (episode.Response.Equals("False"))
            {
                throw new HttpRequestException(episode.Error);
            }
            
            return episode;
        }

        private Season GetSeason(string seriesId, string seriesTitle, int seasonNumber)
        {
            if (seasonNumber <= 0)
            {
                throw new ArgumentOutOfRangeException("Season number has to be greater than zero.", nameof(seasonNumber));
            }

            var query = GetSeasonEpisodeQuery(seriesId, seriesTitle, seasonNumber, null);
            
            var season = GetOmdbDataAsync<Season>(query).Result;
            
            if (season.Response.Equals("False"))
            {
                throw new HttpRequestException(season.Error);
            }
            
            return season;
        }

        private static string GetSeasonEpisodeQuery(string seriesId, string seriesTitle, int seasonNumber, int? episodeNumber)
        {
            string query;

            if (seriesId != null)
            {
                query = $"&i={seriesId}";
            } 
            else if (seriesTitle != null)
            {
                query = $"&t={seriesTitle}";
            }
            else
            {
                throw new ArgumentNullException("Not both seriesId and seriesTitle can be null.");
            }

            query += $"&season={seasonNumber}";

            if (episodeNumber != null)
            {
                query += $"&episode={episodeNumber}";
            }

            return query;
        }
        
        #endregion
    }
}
