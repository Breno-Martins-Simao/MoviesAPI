using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MoviesApi.Tests.Mock;
using MoviesAPI.Controllers;
using MoviesAPI.Interfaces;
using MoviesAPI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Tests.Systems.Controllers
{
    public class MoviesControllerTests
    {
        [Fact]
        public async Task GetHistory_ShouldReturn200Status()
        {
            ///Arrange===========================
            var loggerMock = new Mock<ILogger<MoviesController>>();
            ILogger<MoviesController> logger = loggerMock.Object;

            /*Db Service Setup*/
            var dbServiceMock = new Mock<IDbService>();
            dbServiceMock.Setup(_ => _.GetSearches())
                .Returns(DbMockData.GetSearches());
            IDbService dbService = dbServiceMock.Object;

            /*Movie Service Setup*/
            var movieServiceMock = new Mock<IMoviesService>();
            movieServiceMock.Setup(_ => _.SearchMovie(It.IsAny<string>()))
                .Returns(MovieServiceMockData.SearchMovie());
            IMoviesService movieService = movieServiceMock.Object;

            /*System Under Test*/
            var sut = new MoviesController(logger, movieService, dbService);

            //Act=============================
            var result = await sut.GetHistory();
            //Assert==========================
            result.GetType().Should().Be(typeof(ActionResult<List<SearchHistory>>));
        }
    }
}
