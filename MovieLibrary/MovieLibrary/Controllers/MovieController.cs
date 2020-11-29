using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MovieLibrary.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MovieController : ApiController
    {
        public IMovieRepository InitRepo()
        {
            MovieLibraryFactory factory = new RepositoryFactory();
            IMovieRepository repo = factory.GetRepository();
            return repo;
        }

        [Route("movies/")]
        [HttpGet]
        public IHttpActionResult GetAllMovies()
        {
            return Ok(InitRepo().GetAll());
        }

        [Route("movie/{movieId}")]
        [HttpGet]
        public IHttpActionResult GetMovie(int movieId)
        {
            var result = InitRepo().Get(movieId);

            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        
        [HttpGet]
        public IHttpActionResult GetMoviesByRating(string movieRating)
        {
            if (movieRating.ToUpper() == "G"
                || movieRating.ToUpper() == "PG"
                || movieRating.ToUpper() == "PG-13"
                || movieRating.ToUpper() == "R")
            {
                return Ok(InitRepo().GetMoviesByRating(movieRating));
            }
            else
            {
                return BadRequest();
            }
        }

        
        [HttpGet]
        public IHttpActionResult GetMoviesByTitle(string movieTitle)
        {
            var result = InitRepo().GetMoviesByTitle(movieTitle);

            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        
        [HttpGet]
        public IHttpActionResult GetMoviesByYear(string movieYear)
        {
            if (movieYear.All(c => char.IsDigit(c)) && movieYear.Length == 4)
            {
                var result = InitRepo().GetMoviesByYear(movieYear);
                if (result.Count == 0)
                    return NotFound();
                else
                    return Ok(result);
            }
            else
                return BadRequest();
            
        }

        
        [HttpGet]
        public IHttpActionResult GetMoviesByDirector(string movieDirector)
        {
            var result = InitRepo().GetMoviesByDirector(movieDirector);
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Route("movie/addMovie")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Movie newMovie)
        {
            return Ok(InitRepo().Create(newMovie));
        }

        [Route("movie/{id}")]
        [HttpPut]
        public void Update([FromBody] Movie updatedMovie)
        {
            InitRepo().Update(updatedMovie);
        }

        [Route("movie/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            InitRepo().Delete(id);
        }

        [Route("movies/search")]
        [HttpPut, HttpPost]
        public IHttpActionResult searchBridge([FromBody] searchModel search)
        {
            switch(search.searchType)
            {
                case (int)SearchType.title:
                    return GetMoviesByTitle(search.searchString);
                case (int)SearchType.year:
                    return GetMoviesByYear(search.searchString);
                case (int)SearchType.rating:
                    return GetMoviesByRating(search.searchString);
                case (int)SearchType.director:
                    return GetMoviesByDirector(search.searchString);
                default:
                    return NotFound();

            }
                
        }

        enum SearchType
        {
            title,      // 0
            year,       // 1
            rating,     // 2
            director    // 3
        };

        [Route("movies/thumbsUp/{movieId}")]
        [HttpPost]
        public void ThumbsUp(int movieId)
        {
            InitRepo().ThumbsUp(movieId);
        }

        [Route("movies/thumbsDown/{movieId}")]
        [HttpPost]
        public void ThumbsDown(int movieId)
        {
            InitRepo().ThumbsDown(movieId);
        }
    }
}
