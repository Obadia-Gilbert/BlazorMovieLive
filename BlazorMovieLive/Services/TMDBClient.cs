using System.Net.Http.Json;
using BlazorMovieLive.Models;

namespace BlazorMovieLive.Services
{
    public class TMDBClient
	{
		private readonly HttpClient _httpClient;
		public TMDBClient(HttpClient httpClient, IConfiguration config)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
			_httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));

			string apiKey = config["TMDBKey"] ?? throw new Exception("TMDBKey not found!");
			_httpClient.DefaultRequestHeaders.Authorization = new("Bearer",apiKey);
		}

		public async Task<PopularMoviePagedResponse?> GetPopularMovieAsync(int page = 1)
		{
			if (page < 1) page = 1;

			if (page > 500) page = 500;

			return await _httpClient.GetFromJsonAsync<PopularMoviePagedResponse>($"movie/popular?page={page}");
		}

		public async Task<MovieDetails?> GetMovieDetailsAsync(int id)
		{
			return await  _httpClient.GetFromJsonAsync<MovieDetails>($"movie/{id}");
		}
	}
}

