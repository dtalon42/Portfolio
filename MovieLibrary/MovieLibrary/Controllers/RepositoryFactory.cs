using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MovieLibrary.Controllers
{
    public class RepositoryFactory : MovieLibraryFactory
    {
        public override IMovieRepository GetRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "SampleData":
                    return new MovieRepositoryMock();
                case "ADO":
                    return new MovieRepositoryADO();
                default:
                    throw new ApplicationException(string.Format("This ORM is not supported."));

            }
        }
    }
}