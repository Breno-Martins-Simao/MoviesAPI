using AutoFixture;
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
            return _Fixture.Create<List<SearchHistory>>();
        }

    }
}
