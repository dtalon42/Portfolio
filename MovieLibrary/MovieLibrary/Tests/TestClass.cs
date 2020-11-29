using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieLibrary.Models;
using MovieLibrary.Controllers;
using System.Web.Http;
using System.Web.Http.Results;

namespace MovieLibrary.Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestGetAllMovies()
        {
            MovieController controller = new MovieController();
            IHttpActionResult testList = controller.GetAllMovies();
            var contentResult = testList as OkNegotiatedContentResult<List<Movie>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(7, contentResult.Content.Count); // only for mock repository
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        public void TestGetMovie(int movieId, int expectedId)
        {
            MovieController controller = new MovieController();
            IHttpActionResult testMovie = controller.GetMovie(movieId);
            var contentResult = testMovie as OkNegotiatedContentResult<Movie>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(expectedId, contentResult.Content.movieId);
        }

        [TestCase("super tale", 0, 2)]
        [TestCase("2015", 1, 4)]
        [TestCase("pg", 2, 4)]
        [TestCase("sam jones", 3, 2)]
        public void TestSearchMovie(string searchString, int searchType, int expectedResultCount)
        {
            searchModel search = new searchModel();
            search.searchString = searchString;
            search.searchType = searchType;
            MovieController controller = new MovieController();

            IHttpActionResult testList = controller.searchBridge(search);
            var contentResult = testList as OkNegotiatedContentResult<List<Movie>>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(expectedResultCount, contentResult.Content.Count);
            
            
        }

        [Test]
        public void TestAddMovie()
        {
            var movieId = 8;
            var expectedId = movieId;

            Movie testMovie = new Movie { title = "A Testing Tale", releaseYear = "1999", director = "Test Admin", rating = "G", description = "A tale for testing!", thumbsUp = 34, thumbsDown = 26 };
            MovieController controller = new MovieController();

            controller.Create(testMovie);

            IHttpActionResult testResult = controller.GetMovie(movieId);
            var contentResult = testResult as OkNegotiatedContentResult<Movie>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(expectedId, contentResult.Content.movieId);

        }

        [Test]
        public void TestEditMovie()
        {
            var movieId = 8;
            var expectedYear = "2020";

            Movie testMovie = new Movie { title = "A Testing Tale", releaseYear = "1999", director = "Test Admin", rating = "G", description = "A tale for testing!", thumbsUp = 34, thumbsDown = 26 };
            Movie editMovie = new Movie {movieId = 8, title = "A Testing Tale", releaseYear = "2020", director = "Test Admin", rating = "G", description = "A tale for testing!", thumbsUp = 34, thumbsDown = 26 };
            MovieController controller = new MovieController();

            controller.Create(testMovie);
            controller.Update(editMovie);


            IHttpActionResult testResult = controller.GetMovie(movieId);
            var contentResult = testResult as OkNegotiatedContentResult<Movie>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(expectedYear, contentResult.Content.releaseYear);
        }

        [Test]
        public void TestDeleteMovie()
        {
            var movieId = 8;
            var expectedId = movieId;

            Movie testMovie = new Movie { title = "A Testing Tale", releaseYear = "1999", director = "Test Admin", rating = "G", description = "A tale for testing!", thumbsUp = 34, thumbsDown = 26 };
            MovieController controller = new MovieController();

            controller.Create(testMovie);

            IHttpActionResult testResult = controller.GetAllMovies();
            var contentResult = testResult as OkNegotiatedContentResult<List<Movie>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(8, contentResult.Content.Count); // test repo has 7 movies so +1 is 8

            controller.Delete(movieId);

            IHttpActionResult testList = controller.GetAllMovies();
            contentResult = testList as OkNegotiatedContentResult<List<Movie>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(7, contentResult.Content.Count); // after delete, expect 7 in test repo as 8 - 1


        }

        [Test]
        public void TestThumbs()
        {
            var movieId = 1;
            MovieController controller = new MovieController();

            IHttpActionResult baseMovie = controller.GetMovie(movieId); 
            var baseResult = baseMovie as OkNegotiatedContentResult<Movie>;

            Assert.AreEqual(1, baseResult.Content.thumbsUp);
            Assert.AreEqual(1, baseResult.Content.thumbsDown);

            //baseresult will update after the calls to increment the thumbsup/thumbsdown values

            controller.ThumbsUp(movieId);
            controller.ThumbsDown(movieId);

            Assert.AreEqual(2, baseResult.Content.thumbsUp);
            Assert.AreEqual(2, baseResult.Content.thumbsDown);

        }

    }
}