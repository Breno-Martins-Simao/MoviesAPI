using MoviesAPI.Interfaces;
using MoviesAPI.Models.AppSettings;

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

        public void WriteMessage(string message)
        {
            Console.WriteLine($"MyDependency.WriteMessage called. Message: {message}");
        }
    }
}
