using MoviesAPI.Models.Database;
using MoviesAPI.Models.Omdb;

namespace MoviesAPI.Interfaces
{
    public interface IDbService
    {
        void SaveSearch(OmdbSearchResponse searchResponse, string query);
        List<SearchHistory> GetSearches();
        List<Movie> GetMovies();
    }
}
