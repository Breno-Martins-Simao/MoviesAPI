using MoviesAPI.Database;
using MoviesAPI.Interfaces;
using MoviesAPI.Models.Database;
using MoviesAPI.Models.Omdb;

namespace MoviesAPI.Services
{
    public class DbService : IDbService
    {
        private readonly DatabaseContext _DbContext;
        public DbService()
        {
            _DbContext = new DatabaseContext();
        }

        public void SaveSearch(OmdbSearchResponse searchResponse, string query)
        {
            (Movie movie, SearchHistory search) = ConvertLogFromOmdbResult(searchResponse, query);
            search.MovieResulted = movie;
            _DbContext.SearchHistories.Add(search);
            _DbContext.SaveChanges();
        }

        public List<SearchHistory> GetSearches()
        {
            return _DbContext.SearchHistories.ToList();
        }

        public List<Movie> GetMovies()
        {
            return _DbContext.Movies.ToList();
        }

        private static (Movie, SearchHistory) ConvertLogFromOmdbResult(OmdbSearchResponse searchResponse, string query)
        {
            var movieResulted = new Movie()
            {
                Actors = searchResponse.Actors,
                Awards = searchResponse.Awards,
                Country = searchResponse.Country,
                Director = searchResponse.Director,
                Genre = searchResponse.Genre,
                ImdbID = searchResponse.imdbId,
                ImdbRating = searchResponse.imdbRating,
                ImdbVotes = searchResponse.imdbVotes,
                Language = searchResponse.Language,
                Metascore = searchResponse.Metascore,
                Plot = searchResponse.Plot,
                Poster = searchResponse.Poster,
                Rated = searchResponse.Rated,
                Released = searchResponse.Released,
                Response = searchResponse.Response,
                Runtime = searchResponse.Runtime,
                Title = searchResponse.Title,
                TotalSeassons =searchResponse.totalSeasson,
                Type = searchResponse.Type,
                Writer = searchResponse.Writer,
                Year = searchResponse.Year
            };

            var search = new SearchHistory()
            {
                MovieResulted = movieResulted,
                Query = query
            };

            return (movieResulted, search);
        }
    }
}
