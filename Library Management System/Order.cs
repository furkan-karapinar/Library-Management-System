using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Order
    {
        public int Order_Number { get; set; }
        public string Member { get; set; }
        public Book Book { get; set; }
        
    }
}
