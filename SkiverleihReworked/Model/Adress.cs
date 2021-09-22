using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiverleihReworked.Model
{
    public class Adress
    {
        public int AdressID { get; set; }
        public string Street { get; set; }
        public int Housenumber { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
