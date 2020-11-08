using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DvdLibrary.Controllers;
using DvdLibrary.Models;

namespace DvdLibrary.Models
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static List<Dvd> _dvds = new List<Dvd>()
            {
                new Dvd { dvdId = 1, title = "A Great Tale", releaseYear = "2015", director = "Sam Jones", rating = "PG", notes = "This really is a great tale!"  },
                new Dvd { dvdId = 2, title = "A Good Tale", releaseYear = "2012", director = "Joe Smith", rating = "PG-13", notes = "This is a good tale!"  },
                new Dvd { dvdId = 3, title = "A Super Tale", releaseYear = "2015", director = "Sam Jones", rating = "PG", notes = "A great remake!"  },
                new Dvd { dvdId = 4, title = "A Super Tale", releaseYear = "1985", director = "Joe Smith", rating = "PG", notes = "The original!"  },
                new Dvd { dvdId = 5, title = "A Wonderful Tale", releaseYear = "2015", director = "Joe Smith", rating = "PG-13", notes = "Wonderful, just wonderful!"  },
                new Dvd { dvdId = 6, title = "Just A Tale", releaseYear = "2015", director = "Joe Baker", rating = "PG", notes = "It is a tale!"  },
                new Dvd { dvdId = 7, title = "A New Tale", releaseYear = "2016", director = "Jack Jameson", rating = "PG-13", notes = "Brand spanking new!"  }
            };

        public List<Dvd> GetAll()
        {
            return _dvds;
        }

        public Dvd Get(int dvdId)
        {
            return _dvds.FirstOrDefault(c => c.dvdId == dvdId);
        }

        public List<Dvd> GetDvdsByTitle(string dvdTitle)
        {
            return _dvds.FindAll(c => c.title.ToLower().Contains(dvdTitle.ToLower()));
        }

        public List<Dvd> GetDvdsByYear(string dvdYear)
        {
            return _dvds.FindAll(c => c.releaseYear.Contains(dvdYear));
        }

        public List<Dvd> GetDvdsByDirector(string dvdDirector)
        {
            return _dvds.FindAll(c => c.director.ToLower().Contains(dvdDirector.ToLower()));
        }

        public List<Dvd> GetDvdsByRating(string dvdRating)
        {
            return _dvds.FindAll(c => c.rating.ToLower().Contains(dvdRating.ToLower()));
        }

        public Dvd Create(Dvd newDvd)
        {
            if(_dvds.Any())
            {
                newDvd.dvdId = _dvds.Max(c => c.dvdId) + 1;
            }
            else
            {
                newDvd.dvdId = 1;
            }

            _dvds.Add(newDvd);

            return _dvds.Last();
        }

        public void Update(Dvd updatedDvd)
        {
            _dvds.RemoveAll(c => c.dvdId == updatedDvd.dvdId);
            _dvds.Add(updatedDvd);
        }

        public void Delete(int dvdId)
        {
            _dvds.RemoveAll(c => c.dvdId == dvdId);
        }
    }
}