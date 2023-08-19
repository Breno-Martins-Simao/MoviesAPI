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
            var movieFounded = await _moviesService.SearchMovie(query);
            _dbService.SaveSearch(movieFounded, query);
            if (movieFounded.Response.Equals("False")) return NoContent();
            return Ok(movieFounded);
        }

        [HttpGet()]
        [Route("Search")]
        public async Task<ActionResult<List<SearchHistory>>> GetHistory()
        {
            var searches = _dbService.GetSearches();
            if (searches.Count == 0) return NoContent();
            return Ok(searches);
        }

        [HttpGet()]
        public ActionResult<List<Movie>> GetMoviesFromDb()
        {
            var movies = _dbService.GetMovies();
            if (movies.Count == 0) return NoContent();
            return Ok(movies);
        }
    }
}