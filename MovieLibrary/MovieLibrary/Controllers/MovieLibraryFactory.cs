using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MovieLibrary.Controllers
{
    public abstract class MovieLibraryFactory
    {
        public abstract IMovieRepository GetRepository();
    }
}