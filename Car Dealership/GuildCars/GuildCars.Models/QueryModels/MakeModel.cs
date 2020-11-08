using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.QueryModels
{
    public class MakeModel
    {
        public string make { get; set; }
        public string model { get; set; }

        public DateTime dateAdded { get; set; }

        public string addedBy { get; set; }
    }
}
