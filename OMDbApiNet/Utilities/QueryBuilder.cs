using System;
using System.Text.RegularExpressions;

namespace OMDbApiNet.Utilities
{
	/// <summary>
	/// This class contains the methods for building the query to be sent to OMDb.
	/// </summary>
	public static class QueryBuilder
	{
		public static string GetItemByTitleQuery(string title, OmdbType type, int? year, bool fullPlot)
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
				if (year > 1800)
				{
					query += $"&y={year}";
				}
				else
				{
					throw new ArgumentOutOfRangeException("Year has to be greater than 1800.", nameof(year));
				}
			}

			if (type != OmdbType.None)
			{
				query += $"&type={type.ToString()}";
			}

			return query;
		}

		public static string GetItemByIdQuery(string id, bool fullPlot)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));
			}
            
			var plot = fullPlot ? "full" : "short";

			var query = $"&i={id}&plot={plot}";

			return query;
		}

		public static string GetSearchListQuery(int? year, string query, OmdbType type, int page)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException("Value cannot be null or whitespace.", nameof(query));
			}
            
			if (page <= 0)
			{
				throw new ArgumentOutOfRangeException("Page has to be greater than zero.", nameof(page));
			}

			var editedQuery = $"&s={Regex.Replace(query, @"\s+", "+")}&page={page}";
            
			if (type != OmdbType.None)
			{
				editedQuery += $"&type={type.ToString()}";
			}

			if (year != null)
			{
				if (year > 1800)
				{
					editedQuery += $"&y={year}";
				}
				else
				{
					throw new ArgumentOutOfRangeException("Year has to be greater than 1800.", nameof(year));
				}
			}

			return editedQuery;
		}

		public static string GetEpisodeByEpisodeIdQuery(string episodeId)
		{
			if (string.IsNullOrWhiteSpace(episodeId))
			{
				throw new ArgumentException("Value cannot be null or whitespace.", nameof(episodeId));
			}

			return $"&i={episodeId}";
		}
		
		public static string GetSeasonEpisodeQuery(string seriesId, string seriesTitle, int seasonNumber, int? episodeNumber)
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
	}
}
