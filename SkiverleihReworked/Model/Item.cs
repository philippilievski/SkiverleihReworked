using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiverleihReworked.Model
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }
        public List<CustomerItem> CustomerItems { get; set; }
    }
}
