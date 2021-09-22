using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiverleihReworked.Model
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Adress Adress { get; set; }
        public List<CustomerItem> CustomerItems { get; set; }
        public string Fullname
        {
            get { return this.Firstname + " " + this.Lastname; }
        }
    }
}
