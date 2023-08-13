using AutoFixture;
using MoviesAPI.Models.Omdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Tests.Mock
{
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
