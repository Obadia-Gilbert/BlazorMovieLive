using System.Text.Json.Serialization;

namespace BlazorMovieLive.Models
{
	public class PopularMoviePagedResponse
	{
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public IEnumerable<PopularMovie> Results { get; set; } = [];

        [JsonPropertyName("total_page")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
}


