﻿using AutoFixture;
using MoviesAPI.Models.Database;
using MoviesAPI.Models.Omdb;

namespace MoviesApi.Tests.Mock
{
    public class DbMockData
    {
        private static Fixture _Fixture = new Fixture();

        public static List<SearchHistory> GetSearches()
        {
            var searchs = _Fixture.Create<List<SearchHistory>>();
            return searchs;
        }

        public static List<SearchHistory> GetEmptySearches()
        {
            var searchs = new List<SearchHistory>();
            return searchs;
        }

        public static List<Movie> GetMovies()
        {
            var movies = _Fixture.Create<List<Movie>>();
            return movies;
        }

        public static List<Movie> GetMoviesEmpty()
        {
            var movies = new List<Movie>();
            return movies;
        }
    }

    public class MovieServiceMockData
    {
        private static Fixture _Fixture = new Fixture();

        public static async Task<OmdbSearchResponse> SearchMovie()
        {
            await Task.Delay(100);
            return _Fixture.Create<OmdbSearchResponse>();
        }
    }
}
