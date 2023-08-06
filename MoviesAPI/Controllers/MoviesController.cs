using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Interfaces;

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

        [HttpGet(Name = "Movies")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}