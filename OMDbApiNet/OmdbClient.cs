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
                query += year;
            }
            
            if (type != OmdbType.None)
            {
                query += type.ToString();
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
            if (page < 1 || page > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            var searchList = GetOmdbData<SearchList>($"&s={query}&page={page}").Result;
            return searchList;
        }

        public Episode GetEpisode(string seriesId, uint seasonNumber, uint episodeNumber) 
        {
            if (seasonNumber == 0 || episodeNumber == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var episode = GetOmdbData<Episode>($"&i={seriesId}&season={seasonNumber}&episode{episodeNumber}").Result;
            return episode;
        }

        public Season GetSeason(string seriesId, uint seasonNumber)
        {
            if (seasonNumber == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var season = GetOmdbData<Season>($"&i={seriesId}&season={seasonNumber}").Result;
            return season;
        }

        #endregion

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
                    Error = delegate(object sender, ErrorEventArgs args) 
                    { 
                        var currentError = args.ErrorContext.Error.Message;
                        args.ErrorContext.Handled = true;
                    }
                });
            }
        }
    }
}
