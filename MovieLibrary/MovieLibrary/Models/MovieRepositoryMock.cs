using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MovieLibrary.Controllers;
using MovieLibrary.Models;

namespace MovieLibrary.Models
{
    public class MovieRepositoryMock : IMovieRepository
    {
        private static List<Movie> _movies = new List<Movie>()
            {
                new Movie { movieId = 1, title = "A Great Tale", releaseYear = "2015", director = "Sam Jones", rating = "PG", description = "This really is a great tale!", thumbsUp = 1, thumbsDown = 1  },
                new Movie { movieId = 2, title = "A Good Tale", releaseYear = "2012", director = "Joe Smith", rating = "PG-13", description = "This is a good tale!", thumbsUp = 2, thumbsDown = 2  },
                new Movie { movieId = 3, title = "A Super Tale", releaseYear = "2015", director = "Sam Jones", rating = "PG", description = "A great remake!", thumbsUp = 3, thumbsDown = 3  },
                new Movie { movieId = 4, title = "A Super Tale", releaseYear = "1985", director = "Joe Smith", rating = "PG", description = "The original!", thumbsUp = 4, thumbsDown = 4  },
                new Movie { movieId = 5, title = "A Wonderful Tale", releaseYear = "2015", director = "Joe Smith", rating = "PG-13", description = "Wonderful, just wonderful!", thumbsUp = 5, thumbsDown = 5  },
                new Movie { movieId = 6, title = "Just A Tale", releaseYear = "2015", director = "Joe Baker", rating = "PG", description = "It is a tale!", thumbsUp = 6, thumbsDown = 6  },
                new Movie { movieId = 7, title = "A New Tale", releaseYear = "2016", director = "Jack Jameson", rating = "PG-13", description = "Brand spanking new!", thumbsUp = 7, thumbsDown = 7  }
            };

        public List<Movie> GetAll()
        {
            return _movies;
        }

        public Movie Get(int movieId)
        {
            return _movies.FirstOrDefault(c => c.movieId == movieId);
        }

        public List<Movie> GetMoviesByTitle(string movieTitle)
        {
            return _movies.FindAll(c => c.title.ToLower().Contains(movieTitle.ToLower()));
        }

        public List<Movie> GetMoviesByYear(string movieYear)
        {
            return _movies.FindAll(c => c.releaseYear.Contains(movieYear));
        }

        public List<Movie> GetMoviesByDirector(string movieDirector)
        {
            return _movies.FindAll(c => c.director.ToLower().Contains(movieDirector.ToLower()));
        }

        public List<Movie> GetMoviesByRating(string movieRating)
        {
            return _movies.FindAll(c => c.rating.ToLower().Equals(movieRating.ToLower()));    //Contains(movieRating.ToLower()));
        }

        public Movie Create(Movie newMovie)
        {
            if(_movies.Any())
            {
                newMovie.movieId = _movies.Max(c => c.movieId) + 1;
            }
            else
            {
                newMovie.movieId = 1;
            }

            _movies.Add(newMovie);

            return _movies.Last();
        }

        public void Update(Movie updatedMovie)
        {
            //var movieToEdit = _movies.FirstOrDefault(c => c.movieId == updatedMovie.movieId);
            _movies[updatedMovie.movieId - 1] = updatedMovie; 
        }

        public void Delete(int movieId)
        {
            _movies.RemoveAll(c => c.movieId == movieId);
        }

        public void ThumbsUp(int movieId)
        {
            var thumbs = _movies.FirstOrDefault(c => c.movieId == movieId);
            thumbs.thumbsUp = thumbs.thumbsUp + 1;
        }

        public void ThumbsDown(int movieId)
        {
            var thumbs = _movies.FirstOrDefault(c => c.movieId == movieId);
            thumbs.thumbsDown = thumbs.thumbsDown + 1;
        }
    }
}