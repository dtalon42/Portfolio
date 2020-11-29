using MovieLibrary.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MovieLibrary.Models
{
    public class MovieRepositoryADO : IMovieRepository
    {
        public Movie Create(Movie newMovie)
        {
            Movie movie = new Movie();

            // creates new dvd
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MovieLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "CreateMovie";

                cmd.Parameters.AddWithValue("@title", newMovie.title);
                cmd.Parameters.AddWithValue("@releaseYear", newMovie.releaseYear);
                cmd.Parameters.AddWithValue("@director", newMovie.director);
                cmd.Parameters.AddWithValue("@rating", newMovie.rating);
                cmd.Parameters.AddWithValue("@description", newMovie.description);
                cmd.Parameters.AddWithValue("@thumbsUp", newMovie.thumbsUp);
                cmd.Parameters.AddWithValue("@thumbsDown", newMovie.thumbsDown);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // retrieves last dvd
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MovieLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "LastMovie";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        movie.movieId = (int)dr["movieId"]; // primary key, can't be null
                        movie.title = dr["title"].ToString();
                        movie.releaseYear = dr["releaseYear"].ToString();
                        movie.director = dr["director"].ToString();
                        movie.rating = dr["rating"].ToString();
                        movie.description = dr["description"].ToString();
                        movie.thumbsUp = (int)dr["thumbsUp"];
                        movie.thumbsDown = (int)dr["thumbsDown"];

                    }
                }

            }
            return movie;
        }

        public void Delete(int movieId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MovieLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "DeleteMovie";
                cmd.Parameters.AddWithValue("@id", movieId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Movie Get(int movieId)
        {
            Movie movie = new Movie();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MovieLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "MovieById";
                cmd.Parameters.AddWithValue("@id", movieId);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        movie.movieId = (int)dr["movieId"]; // primary key, can't be null
                        movie.title = dr["title"].ToString();
                        movie.releaseYear = dr["releaseYear"].ToString();
                        movie.director = dr["director"].ToString();
                        movie.rating = dr["rating"].ToString();
                        movie.description = dr["description"].ToString();
                        movie.thumbsUp = (int)dr["thumbsUp"];
                        movie.thumbsDown = (int)dr["thumbsDown"];

                    }
                }
            }
            return movie;
        }

        public List<Movie> GetAll()
        {
            List<Movie> allMovies = new List<Movie>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MovieLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "AllMovies";

                conn.Open();
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        Movie currentRow = new Movie();

                        currentRow.movieId = (int)dr["movieId"]; // primary key, can't be null
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.description = dr["description"].ToString();
                        currentRow.thumbsUp = (int)dr["thumbsUp"];
                        currentRow.thumbsDown = (int)dr["thumbsDown"];

                        allMovies.Add(currentRow);
                    }
                }
            }

            return allMovies;
        }

        public List<Movie> GetMoviesByDirector(string movieDirector)
        {
            List<Movie> directorMovies = new List<Movie>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MovieLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "MovieByDirector";
                cmd.Parameters.AddWithValue("@director", movieDirector);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Movie currentRow = new Movie();

                        currentRow.movieId = (int)dr["movieId"]; // primary key, can't be null
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.description = dr["description"].ToString();
                        currentRow.thumbsUp = (int)dr["thumbsUp"];
                        currentRow.thumbsDown = (int)dr["thumbsDown"];

                        directorMovies.Add(currentRow);
                    }
                }
            }

            return directorMovies;
        }

        public List<Movie> GetMoviesByRating(string movieRating)
        {
            List<Movie> ratingMovies = new List<Movie>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MovieLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "MovieByRating";
                cmd.Parameters.AddWithValue("@rating", movieRating);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Movie currentRow = new Movie();

                        currentRow.movieId = (int)dr["movieId"]; // primary key, can't be null
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.description = dr["description"].ToString();
                        currentRow.thumbsUp = (int)dr["thumbsUp"];
                        currentRow.thumbsDown = (int)dr["thumbsDown"];

                        ratingMovies.Add(currentRow);
                    }
                }
            }

            return ratingMovies;
        }

        public List<Movie> GetMoviesByTitle(string movieTitle)
        {
            List<Movie> titleMovies = new List<Movie>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MovieLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "MovieByTitle";
                cmd.Parameters.AddWithValue("@title", movieTitle);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Movie currentRow = new Movie();

                        currentRow.movieId = (int)dr["movieId"]; // primary key, can't be null
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.description = dr["description"].ToString();
                        currentRow.thumbsUp = (int)dr["thumbsUp"];
                        currentRow.thumbsDown = (int)dr["thumbsDown"];

                        titleMovies.Add(currentRow);
                    }
                }
            }

            return titleMovies;
        }

        public List<Movie> GetMoviesByYear(string movieYear)
        {
            List<Movie> yearMovies = new List<Movie>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MovieLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "MovieByYear";
                cmd.Parameters.AddWithValue("@year", movieYear);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Movie currentRow = new Movie();

                        currentRow.movieId = (int)dr["movieId"]; // primary key, can't be null
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.description = dr["description"].ToString();
                        currentRow.thumbsUp = (int)dr["thumbsUp"];
                        currentRow.thumbsDown = (int)dr["thumbsDown"];

                        yearMovies.Add(currentRow);
                    }
                }
            }

            return yearMovies;
        }

        public void Update(Movie updatedMovie)
        {

            // updates dvd
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MovieLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "UpdateMovie";

                cmd.Parameters.AddWithValue("@Id", updatedMovie.movieId);
                cmd.Parameters.AddWithValue("@title", updatedMovie.title);
                cmd.Parameters.AddWithValue("@releaseYear", updatedMovie.releaseYear);
                cmd.Parameters.AddWithValue("@director", updatedMovie.director);
                cmd.Parameters.AddWithValue("@rating", updatedMovie.rating);
                cmd.Parameters.AddWithValue("@description", updatedMovie.description);
                cmd.Parameters.AddWithValue("@thumbsUp", updatedMovie.thumbsUp);
                cmd.Parameters.AddWithValue("@thumbsDown", updatedMovie.thumbsDown);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ThumbsUp(int movieId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MovieLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "ThumbsUp";
                cmd.Parameters.AddWithValue("@Id", movieId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void ThumbsDown(int movieId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MovieLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "ThumbsDown";
                cmd.Parameters.AddWithValue("@Id", movieId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}