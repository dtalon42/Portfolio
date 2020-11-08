using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDManager.Models
{
    public class CD
    {
        public int id;
        public string title;
        public string artist;
        public string[] tracklist;
        public TimeSpan runtime;

    }
}
