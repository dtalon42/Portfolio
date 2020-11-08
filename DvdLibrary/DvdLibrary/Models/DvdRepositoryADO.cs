using DvdLibrary.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DvdLibrary.Models
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public Dvd Create(Dvd newDvd)
        {
            Dvd dvd = new Dvd();

            // creates new dvd
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "CreateDvd";

                cmd.Parameters.AddWithValue("@title", newDvd.title);
                cmd.Parameters.AddWithValue("@releaseYear", newDvd.releaseYear);
                cmd.Parameters.AddWithValue("@director", newDvd.director);
                cmd.Parameters.AddWithValue("@rating", newDvd.rating);
                cmd.Parameters.AddWithValue("@notes", newDvd.notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // retrieves last dvd
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "LastDvd";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        dvd.dvdId = (int)dr["dvdId"]; // primary key, can't be null
                        dvd.title = dr["title"].ToString();
                        dvd.releaseYear = dr["releaseYear"].ToString();
                        dvd.director = dr["director"].ToString();
                        dvd.rating = dr["rating"].ToString();
                        dvd.notes = dr["notes"].ToString();

                    }
                }

            }
            return dvd;
        }

        public void Delete(int dvdId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "DeleteDvd";
                cmd.Parameters.AddWithValue("@id", dvdId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Dvd Get(int dvdId)
        {
            Dvd dvd = new Dvd();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "DvdById";
                cmd.Parameters.AddWithValue("@id", dvdId);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        dvd.dvdId = (int)dr["dvdId"]; // primary key, can't be null
                        dvd.title = dr["title"].ToString();
                        dvd.releaseYear = dr["releaseYear"].ToString();
                        dvd.director = dr["director"].ToString();
                        dvd.rating = dr["rating"].ToString();
                        dvd.notes = dr["notes"].ToString();

                    }
                }
            }
            return dvd;
        }

        public List<Dvd> GetAll()
        {
            List<Dvd> allDvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "AllDvds";

                conn.Open();
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.dvdId = (int)dr["dvdId"]; // primary key, can't be null
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();

                        allDvds.Add(currentRow);
                    }
                }
            }

            return allDvds;
        }

        public List<Dvd> GetDvdsByDirector(string dvdDirector)
        {
            List<Dvd> directorDvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "DvdByDirector";
                cmd.Parameters.AddWithValue("@director", dvdDirector);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.dvdId = (int)dr["dvdId"]; // primary key, can't be null
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();

                        directorDvds.Add(currentRow);
                    }
                }
            }

            return directorDvds;
        }

        public List<Dvd> GetDvdsByRating(string dvdRating)
        {
            List<Dvd> ratingDvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "DvdByRating";
                cmd.Parameters.AddWithValue("@rating", dvdRating);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.dvdId = (int)dr["dvdId"]; // primary key, can't be null
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();

                        ratingDvds.Add(currentRow);
                    }
                }
            }

            return ratingDvds;
        }

        public List<Dvd> GetDvdsByTitle(string dvdTitle)
        {
            List<Dvd> titleDvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "DvdByTitle";
                cmd.Parameters.AddWithValue("@title", dvdTitle);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.dvdId = (int)dr["dvdId"]; // primary key, can't be null
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();

                        titleDvds.Add(currentRow);
                    }
                }
            }

            return titleDvds;
        }

        public List<Dvd> GetDvdsByYear(string dvdYear)
        {
            List<Dvd> yearDvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "DvdByYear";
                cmd.Parameters.AddWithValue("@year", dvdYear);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();

                        currentRow.dvdId = (int)dr["dvdId"]; // primary key, can't be null
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();

                        yearDvds.Add(currentRow);
                    }
                }
            }

            return yearDvds;
        }

        public void Update(Dvd updatedDvd)
        {

            // updates dvd
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "UpdateDvd";

                cmd.Parameters.AddWithValue("@Id", updatedDvd.dvdId);
                cmd.Parameters.AddWithValue("@title", updatedDvd.title);
                cmd.Parameters.AddWithValue("@releaseYear", updatedDvd.releaseYear);
                cmd.Parameters.AddWithValue("@director", updatedDvd.director);
                cmd.Parameters.AddWithValue("@rating", updatedDvd.rating);
                cmd.Parameters.AddWithValue("@notes", updatedDvd.notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}