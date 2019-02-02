using System;
using System.Net.Http;
using Xunit;
using OMDbApiNet;

namespace TestOmdbApiNet
{
	/*
     * Data in these unit tests last checked on 02/02/2019 (American date format).
     */
	public class SearchAsyncTest
	{
		[Fact]
		public async void TestGetSearchListGood()
		{
			var omdb = new AsyncOmdbClient(TestData.apikey);
			var searchList = await omdb.GetSearchListAsync("Arrow", 1);

			var search = searchList.SearchResults.ToArray();
			Assert.Equal("Arrow", search[0].Title);
			Assert.Equal("2012–", search[0].Year);
			Assert.Equal("tt2193021", search[0].ImdbId);
			Assert.Equal("series", search[0].Type);
            
			Assert.Equal("Broken Arrow", search[1].Title);
			Assert.Equal("1996", search[1].Year);
			Assert.Equal("tt0115759", search[1].ImdbId);
			Assert.Equal("movie", search[1].Type);

			Assert.Equal("Green Arrow", search[5].Title);
			Assert.Equal("2010", search[5].Year);
			Assert.Equal("tt1663633", search[5].ImdbId);
			Assert.Equal("movie", search[5].Type);

			Assert.Equal(null, searchList.Error);
			Assert.Equal("True", searchList.Response);
		}
        
		[Fact]
		public async System.Threading.Tasks.Task TestGetSearchListBad()
		{
			var omdb = new AsyncOmdbClient(TestData.apikey);

            await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetSearchListAsync(null));
			await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetSearchListAsync(""));
			await Assert.ThrowsAsync<ArgumentException>(() => omdb.GetSearchListAsync(" "));
            
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => omdb.GetSearchListAsync("star wars", 0));
            
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => omdb.GetSearchListAsync(1500, "star wars", 0));
            
			await Assert.ThrowsAsync<HttpRequestException>(() => omdb.GetSearchListAsync("asdf"));
		}
	}
}
