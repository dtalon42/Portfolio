using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Controllers
{
    public interface IDvdRepository
    {
        List<Dvd> GetAll();
        Dvd Get(int dvdId);
        List<Dvd> GetDvdsByTitle(string dvdTitle);
        List<Dvd> GetDvdsByYear(string dvdYear);
        List<Dvd> GetDvdsByDirector(string dvdDirector);
        List<Dvd> GetDvdsByRating(string dvdRating);
        Dvd Create(Dvd newDvd);
        void Update(Dvd updatedDvd);
        void Delete(int dvdId);
    }
}
