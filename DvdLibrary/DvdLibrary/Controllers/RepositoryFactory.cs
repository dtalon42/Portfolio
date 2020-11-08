using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DvdLibrary.Controllers
{
    public class RepositoryFactory : DvdLibraryFactory
    {
        public override IDvdRepository GetRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "SampleData":
                    return new DvdRepositoryMock();
                case "ADO":
                    return new DvdRepositoryADO();
                default:
                    throw new ApplicationException(string.Format("This ORM is not supported."));

            }
        }
    }
}