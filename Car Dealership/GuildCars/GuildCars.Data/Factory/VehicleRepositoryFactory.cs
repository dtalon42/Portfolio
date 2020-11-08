using GuildCars.Data.Interface;
using GuildCars.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factory
{
    public class VehicleRepositoryFactory : GuildCarsFactory
    {
        public override IDealerRepository GetRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch(mode)
            {
                case "QA":
                    throw new NotImplementedException("Under construction");
                case "PROD":
                    return new PRODRepository();
                default:
                    throw new ApplicationException(string.Format("Not an applicable setting."));


            }
        }
    }
}
