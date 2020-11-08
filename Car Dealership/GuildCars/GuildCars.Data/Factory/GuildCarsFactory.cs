using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models;
using GuildCars.Data.Interface;

namespace GuildCars.Data.Factory
{
    public abstract class GuildCarsFactory
    {
        public abstract IDealerRepository GetRepository();
    }
}
