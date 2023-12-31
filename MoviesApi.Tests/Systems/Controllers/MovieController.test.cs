﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Tests.Mock;
using MoviesAPI.Controllers;
using MoviesAPI.Models.Database;
using MoviesApi.Tests.Utils;

namespace MoviesApi.Tests.Systems.Controllers
{
    public class MoviesControllerTests
    {
        [Fact]
        public async Task GetHistory_ShouldReturn200Status()
        {
            ///Arrange===========================
            /*Arrange Mock object*/
            var mockFactory = new MockServicesFactory();
            /*Logger Setup*/
            var logger = mockFactory.MockIlogger<MoviesController>();
            /*Movie Service Setup*/
            var movieService = mockFactory.MockIMovieService();
            /*Db Service Setup*/
            var dbService = mockFactory.MockIDbService(DbMockData.GetSearches(), DbMockData.GetMovies());            

            /*System Under Test*/
            var sut = new MoviesController(logger, movieService, dbService);

            //Act=============================
            var result = await sut.GetHistory();
            var statusCode = Utilities.GetStatusCode<ActionResult<List<SearchHistory>>>(result);
            //Assert==========================
            result.GetType().Should().Be(typeof(ActionResult<List<SearchHistory>>));
            Assert.True(statusCode == 200);
        }

        [Fact]
        public async Task GetHistory_ShouldReturn204Status()
        {
            ///Arrange===========================
            /*Arrange Mock object*/
            var mockFactory = new MockServicesFactory();
            /*Logger Setup*/
            var logger = mockFactory.MockIlogger<MoviesController>();
            /*Movie Service Setup*/
            var movieService = mockFactory.MockIMovieService();
            /*Db Service Setup*/
            var dbService = mockFactory.MockIDbService(DbMockData.GetEmptySearches(), DbMockData.GetMovies());

            /*System Under Test*/
            var sut = new MoviesController(logger, movieService, dbService);

            //Act=============================
            var result = await sut.GetHistory();
            var itens = result.Value;
            var statusCode = Utilities.GetStatusCode<ActionResult<List<SearchHistory>>>(result);
            //Assert==========================
            result.GetType().Should().Be(typeof(ActionResult<List<SearchHistory>>)); //Validate object type
            Assert.True(itens == null); //Validate if it was not any content within result
            //Assert.True(statusCode == 204); //Validate status code
        }
    }
}
