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
	public class AsyncOmdbClient : IAsyncOmdbClient
	{
		private const string BaseUrl = "http://www.omdbapi.com/?";
		private readonly string _apikey;
		private readonly bool _rottenTomatoesRatings;
		
		public AsyncOmdbClient(string apikey, bool rottenTomatoesRatings = false)
		{
			_apikey = apikey;
			_rottenTomatoesRatings = rottenTomatoesRatings;
		}
		
		#region ApiImplementation
		
		public Task<Item> GetItemByTitleAsync(string title, bool fullPlot = false)
		{
			return GetItemByTitleAsync(title, OmdbType.None, null, fullPlot);
		}

		public Task<Item> GetItemByTitleAsync(string title, OmdbType type, bool fullPlot = false)
		{
			return GetItemByTitleAsync(title, type, null, fullPlot);
		}

		public  Task<Item> GetItemByTitleAsync(string title, int? year, bool fullPlot = false)
		{
			return GetItemByTitleAsync(title, OmdbType.None, year, fullPlot);
		}

		public async Task<Item> GetItemByTitleAsync(string title, OmdbType type, int? year, bool fullPlot = false)
		{
			var query = QueryBuilder.GetItemByTitleQuery(title, type, year, fullPlot);
			
			var item = await GetOmdbDataAsync<Item>(query);

			if (item.Response.Equals("False"))
			{
				throw new HttpRequestException(item.Error);
			}
            
			return item;
		}

		public async Task<Item> GetItemByIdAsync(string id, bool fullPlot = false)
		{
			var query = QueryBuilder.GetItemByIdQuery(id, fullPlot);
            
			var item = await GetOmdbDataAsync<Item>(query);
            
			if (item.Response.Equals("False"))
			{
				throw new HttpRequestException(item.Error);
			}
            
			return item;
		}

		public Task<SearchList> GetSearchListAsync(string query, int page = 1)
		{
			return GetSearchListAsync(null, query, OmdbType.None, page);
		}

		public Task<SearchList> GetSearchListAsync(string query, OmdbType type, int page = 1)
		{
			return GetSearchListAsync(null, query, type, page);
		}

		public Task<SearchList> GetSearchListAsync(int? year, string query, int page = 1)
		{
			return GetSearchListAsync(year, query, OmdbType.None, page);
		}

		public async Task<SearchList> GetSearchListAsync(int? year, string query, OmdbType type, int page = 1)
		{
			var editedQuery = QueryBuilder.GetSearchListQuery(year, query, type, page);

			var searchList = await GetOmdbDataAsync<SearchList>(editedQuery);
            
			if (searchList.Response.Equals("False"))
			{
				throw new HttpRequestException(searchList.Error);
			}
            
			return searchList;
		}

		public Task<Episode> GetEpisodeBySeriesIdAsync(string seriesId, int seasonNumber, int episodeNumber)
		{
			if (string.IsNullOrWhiteSpace(seriesId))
			{
				throw new ArgumentException("Value cannot be null or whitespace.", nameof(seriesId));
			}

			return GetEpisodeAsync(seriesId, null, seasonNumber, episodeNumber);
		}

		public Task<Episode> GetEpisodeBySeriesTitleAsync(string seriesTitle, int seasonNumber, int episodeNumber)
		{
			if (string.IsNullOrWhiteSpace(seriesTitle))
			{
				throw new ArgumentException("Value cannot be null or empty.", nameof(seriesTitle));
			}

			return GetEpisodeAsync(null, seriesTitle, seasonNumber, episodeNumber);
		}

		public async Task<Episode> GetEpisodeByEpisodeIdAsync(string episodeId)
		{
			var query = QueryBuilder.GetEpisodeByEpisodeIdQuery(episodeId);
            
			var episode = await GetOmdbDataAsync<Episode>(query);
            
			if (episode.Response.Equals("False"))
			{
				throw new HttpRequestException(episode.Error);
			}
            
			return episode;
		}

		public Task<Season> GetSeasonBySeriesIdAsync(string seriesId, int seasonNumber)
		{
			if (string.IsNullOrWhiteSpace(seriesId))
			{
				throw new ArgumentException("Value cannot be null or whitespace.", nameof(seriesId));
			}

			return GetSeasonAsync(seriesId, null, seasonNumber);
		}

		public Task<Season> GetSeasonBySeriesTitleAsync(string seriesTitle, int seasonNumber)
		{
			if (string.IsNullOrWhiteSpace(seriesTitle))
			{
				throw new ArgumentException("Value cannot be null or whitespace.", nameof(seriesTitle));
			}

			return GetSeasonAsync(null, seriesTitle, seasonNumber);
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
		
		private async Task<Episode> GetEpisodeAsync(string seriesId, string seriesTitle, int seasonNumber, int episodeNumber)
		{
			if (seasonNumber <= 0)
			{
				throw new ArgumentOutOfRangeException("Season number has to be greater than zero.", nameof(seasonNumber));
			}
			if (episodeNumber <= 0)
			{
				throw new ArgumentOutOfRangeException("Episode number has to be greater than zero.", nameof(episodeNumber));
			}

			var query = QueryBuilder.GetSeasonEpisodeQuery(seriesId, seriesTitle, seasonNumber, episodeNumber);
            
			var episode = await GetOmdbDataAsync<Episode>(query);
            
			if (episode.Response.Equals("False"))
			{
				throw new HttpRequestException(episode.Error);
			}
            
			return episode;
		}

		private async Task<Season> GetSeasonAsync(string seriesId, string seriesTitle, int seasonNumber)
		{
			if (seasonNumber <= 0)
			{
				throw new ArgumentOutOfRangeException("Season number has to be greater than zero.", nameof(seasonNumber));
			}

			var query = QueryBuilder.GetSeasonEpisodeQuery(seriesId, seriesTitle, seasonNumber, null);
            
			var season = await GetOmdbDataAsync<Season>(query);
            
			if (season.Response.Equals("False"))
			{
				throw new HttpRequestException(season.Error);
			}
            
			return season;
		}
		
		#endregion
	}
}
