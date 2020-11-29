using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Controllers
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie Get(int movieId);
        List<Movie> GetMoviesByTitle(string movieTitle);
        List<Movie> GetMoviesByYear(string movieYear);
        List<Movie> GetMoviesByDirector(string movieDirector);
        List<Movie> GetMoviesByRating(string movieRating);
        Movie Create(Movie newMovie);
        void Update(Movie updatedMovie);
        void Delete(int dvdId);
        void ThumbsUp(int movieId);
        void ThumbsDown(int movieId);
    }
}
