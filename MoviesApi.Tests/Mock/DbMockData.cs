﻿using AutoFixture;
using MoviesAPI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static List<Movie> GetMovies()
        {
            var movies = _Fixture.Create<List<Movie>>();
            return movies;
        }
    }
}
