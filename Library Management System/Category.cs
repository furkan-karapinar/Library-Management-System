using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Category
    {
      
            public string Name { get; set; }
            public List<Book> Books { get; set; }

            public Category()
            {
                Books = new List<Book>();
            }
        
    }
}
