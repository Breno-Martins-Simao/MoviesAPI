using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Interfaces;
using MoviesAPI.Models.Database;
using MoviesAPI.Models.Omdb;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMoviesService _moviesService;
        private readonly IDbService _dbService;

        public MoviesController(ILogger<MoviesController> logger, IMoviesService moviesService, IDbService dbService)
        {
            _logger = logger;
            _moviesService = moviesService;
            _dbService = dbService;
        }

        [HttpGet()]
        [Route("Search/{query}")]
        public async Task<ActionResult<OmdbSearchResponse>> GetMovie(string query)
        {
            var response = await _moviesService.SearchMovie(query);
            _dbService.SaveSearch(response, query);
            return Ok(response);
        }

        [HttpGet()]
        [Route("Search")]
        public async Task<ActionResult<List<SearchHistory>>> GetHistory()
        {
            var searches = _dbService.GetSearches();
            foreach(var search in searches)
            {
                Console.WriteLine(search.MovieResulted == null);
            }
            return searches;
        }

        [HttpGet()]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            var movies = _dbService.GetMovies();
            return movies;
        }
    }
}