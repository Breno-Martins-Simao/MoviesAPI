using Microsoft.Extensions.Logging;
using MoviesAPI.Interfaces;
using Moq;
using MoviesAPI.Models.Database;

namespace MoviesApi.Tests.Mock
{
    public class MockServicesFactory
    {
        public ILogger<T> MockIlogger<T>()
        {
            var loggerMock = new Mock<ILogger<T>>();
            ILogger<T> logger = loggerMock.Object;
            return logger;
        }

        public IMoviesService MockIMovieService()
        {
            var movieServiceMock = new Mock<IMoviesService>();
            movieServiceMock.Setup(_ => _.SearchMovie(It.IsAny<string>()))
                .Returns(MovieServiceMockData.SearchMovie());
            IMoviesService movieService = movieServiceMock.Object;
            return movieService;
        }

        public IDbService MockIDbService(List<SearchHistory> GetSearchHistoryMock, List<Movie> GetMoviesMock)
        {
            var dbServiceMock = new Mock<IDbService>();
            dbServiceMock.Setup(_ => _.GetSearches())
                .Returns(GetSearchHistoryMock);
            dbServiceMock.Setup(_ => _.GetMovies())
                .Returns(GetMoviesMock);
            IDbService dbService = dbServiceMock.Object;
            return dbService;
        }
    }
}
