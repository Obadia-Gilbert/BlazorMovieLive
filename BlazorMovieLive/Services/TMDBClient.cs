using System;
namespace BlazorMovieLive.Services
{
	public class TMDBClient
	{
		private readonly HttpClient _httpClient;
		public TMDBClient(HttpClient httpClient, IConfiguration config)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
			_httpClient.DefaultRequestHeaders.Accept.Add(new("Applicaton/Json"));

			string ApiKey = config["TMDBKey"] ?? throw new Exception("TMDBKey not found!");
			_httpClient.DefaultRequestHeaders.Authorization = new("Bearer",ApiKey);
		}
	}
}

