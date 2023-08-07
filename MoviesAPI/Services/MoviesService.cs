using MoviesAPI.Interfaces;
using MoviesAPI.Models.AppSettings;
using MoviesAPI.Models.Omdb;
using Newtonsoft.Json;
using System.Web;

namespace MoviesAPI.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly ILogger<MoviesService> _logger;
        private readonly OmdbSettings _omdbSettings;
        private readonly HttpClient _httpClient;

        public MoviesService(ILogger<MoviesService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _omdbSettings = configuration.GetSection("OmdbSettings").Get<OmdbSettings>();
            _httpClient = new HttpClient();
        }

        public async Task<OmdbSearchResponse> SearchMovie(string searchQuery)
        {
#nullable disable
            var builder = new UriBuilder(_omdbSettings.BaseUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["t"] = searchQuery;
            query["apikey"] = _omdbSettings.Apikey;
            builder.Query = query.ToString();

            var response = await _httpClient.GetAsync(builder.ToString());
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OmdbSearchResponse>(jsonString);
        }
    }
}
