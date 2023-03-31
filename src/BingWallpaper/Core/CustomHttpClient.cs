using System.Net.Http.Json;

namespace BingWallpaper.Core
{
	internal class CustomHttpClient : ICustomHttpClient
	{
		private readonly HttpClient _httpClient;

		internal CustomHttpClient(HttpClient httpClient) => _httpClient = httpClient;

		public CustomHttpClient(IHttpClientFactory httpClientFactory)
			=> _httpClient = httpClientFactory.CreateClient();

		public Task<T?> GetFromJsonAsync<T>(string url)
			=> _httpClient.GetFromJsonAsync<T>(url);

		public Task<HttpResponseMessage> GetHttpResponseMessageAsync(string url)
			=> _httpClient.GetAsync(url);

		public Task<Stream> GetStreamAsync(string url) => _httpClient.GetStreamAsync(url);
	}

	internal interface ICustomHttpClient
	{
		Task<T?> GetFromJsonAsync<T>(string url);
		Task<HttpResponseMessage> GetHttpResponseMessageAsync(string url);
		Task<Stream> GetStreamAsync(string url);
	}
}
