using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieLibrary.Models
{
    public class searchModel
    {
        public string searchString { get; set; }

        public int searchType { get; set; } 
        // title, year, rating, director
    }
}