using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiverleihReworked.Model
{
    public class CustomerItem
    {
        public int CustomerItemID { get; set; }
        public DateTime LendDate { get; set; }
        public Item Item { get; set; }
        public Customer Customer { get; set; }
    }
}
