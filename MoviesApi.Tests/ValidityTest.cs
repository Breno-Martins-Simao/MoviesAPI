using MoviesAPI.Services;

namespace MoviesApi.Tests
{
    public class DbTests
    {
        [Fact]
        public void DbConnection()
        {
            var db = new DbService();
            var result = db.GetMovies();
            Assert.NotNull(result);
        }
    }
}