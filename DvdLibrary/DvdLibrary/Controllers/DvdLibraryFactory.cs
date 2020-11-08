using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DvdLibrary.Controllers
{
    public abstract class DvdLibraryFactory
    {
        public abstract IDvdRepository GetRepository();
    }
}