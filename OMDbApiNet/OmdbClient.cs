using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OMDbApiNet.Model;

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

        public Item GetItemByTitle(string title, uint? year, bool fullPlot = false)
        {
            return GetItemByTitle(title, OmdbType.None, year, fullPlot);
        }

        public Item GetItemByTitle(string title, OmdbType type, uint? year, bool fullPlot = false)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(title));
            }

            var editedTitle = Regex.Replace(title, @"\s+", "+");
            var plot = fullPlot ? "full" : "short";

            var query = $"&t={editedTitle}&plot={plot}";
            
            if (year != null)
            {
                query += $"&y={year}";
            }
            
            if (type != OmdbType.None)
            {
                query += $"&type={type.ToString()}";
            }

            var item = GetOmdbData<Item>(query).Result;
            return item;
        }

        public Item GetItemById(string id, bool fullPlot = false)
        {
            var plot = fullPlot ? "full" : "short";
            var item = GetOmdbData<Item>($"&i={id}&plot={plot}").Result;
            return item;
        }

        public SearchList GetSearchList(string query, uint page = 1)
        {
            return GetSearchList(query, OmdbType.None, page);
        }
        
        public SearchList GetSearchList(string query, OmdbType type, uint page = 1)
        {
            if (page == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            var editedQuery = $"&s={Regex.Replace(query, @"\s+", "+")}&page={page}";
            
            if (type != OmdbType.None)
            {
                editedQuery += $"&type={type.ToString()}";
            }

            var searchList = GetOmdbData<SearchList>(editedQuery).Result;
            return searchList;
        }

        public Episode GetEpisodeBySeriesId(string seriesId, uint seasonNumber, uint episodeNumber)
        {
            return GetEpisode(seriesId, null, seasonNumber, episodeNumber);
        }

        public Episode GetEpisodeByTitle(string seriesTitle, uint seasonNumber, uint episodeNumber)
        {
            return GetEpisode(null, seriesTitle, seasonNumber, episodeNumber);
        }

        public Season GetSeasonBySeriesId(string seriesId, uint seasonNumber)
        {
            return GetSeason(seriesId, null, seasonNumber);
        }
        
        public Season GetSeasonByTitle(string seriesTitle, uint seasonNumber)
        {
            return GetSeason(null, seriesTitle, seasonNumber);
        }

        #endregion
        
        #region Internal

        private async Task<T> GetOmdbData<T>(string query)
        {
            using (var client = new HttpClient {BaseAddress = new Uri(BaseUrl)})
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"{BaseUrl}apikey={_apikey}{query}&tomatoes={_rottenTomatoesRatings}").ConfigureAwait(false);
            
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
        
        private Episode GetEpisode(string seriesId, string seriesTitle, uint seasonNumber, uint episodeNumber)
        {
            if (seasonNumber == 0 || episodeNumber == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var query = GetSeasonEpisodeQuery(seriesId, seriesTitle, seasonNumber, episodeNumber);
            
            var episode = GetOmdbData<Episode>(query).Result;
            return episode;
        }

        private Season GetSeason(string seriesId, string seriesTitle, uint seasonNumber)
        {
            if (seasonNumber == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var query = GetSeasonEpisodeQuery(seriesId, seriesTitle, seasonNumber, null);
            
            var season = GetOmdbData<Season>(query).Result;
            return season;
        }

        private static string GetSeasonEpisodeQuery(string seriesId, string seriesTitle, uint seasonNumber, uint? episodeNumber)
        {
            string query;

            if (seriesId != null && seriesTitle == null)
            {
                query = $"&i={seriesId}";
            } 
            else if (seriesTitle != null && seriesId == null)
            {
                query = $"&t={seriesTitle}";
            }
            else
            {
                throw new ArgumentException();
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
