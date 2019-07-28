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

			Assert.Null(searchList.Error);
			Assert.Equal("True", searchList.Response);
		}
		
		public async void TestGetSearchListGood2()
		{
			var omdb = new AsyncOmdbClient(TestData.apikey);
			var searchList = await omdb.GetSearchListAsync("Skyrim", OmdbType.Game);

			var search = searchList.SearchResults.ToArray();
			Assert.Equal("The Elder Scrolls V: Skyrim", search[0].Title);
			Assert.Equal("2011", search[0].Year);
			Assert.Equal("tt1814884", search[0].ImdbId);
			Assert.Equal("game", search[0].Type);
            
			Assert.Equal("The Elder Scrolls V: Skyrim - Dawnguard", search[1].Title);
			Assert.Equal("2012", search[1].Year);
			Assert.Equal("tt5333506", search[1].ImdbId);
			Assert.Equal("game", search[1].Type);

			Assert.Null(searchList.Error);
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
