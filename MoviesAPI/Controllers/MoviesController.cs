using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Interfaces;
using MoviesAPI.Models.Omdb;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMoviesService _moviesService;

        public MoviesController(ILogger<MoviesController> logger, IMoviesService moviesService)
        {
            _logger = logger;
            _moviesService = moviesService;
        }

        [HttpGet()]
        [Route("Search/{query}")]
        public async Task<ActionResult<OmdbSearchResponse>> Get(string query)
        {
            var response = await _moviesService.SearchMovie(query);
            return Ok(response);
        }
    }
}