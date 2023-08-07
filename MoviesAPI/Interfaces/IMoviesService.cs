using MoviesAPI.Models.Omdb;

namespace MoviesAPI.Interfaces
{
    public interface IMoviesService
    {
        Task<OmdbSearchResponse> SearchMovie(string searchQuery);
    }
}
