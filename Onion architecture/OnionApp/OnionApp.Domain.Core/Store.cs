using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Domain.Core
{ 
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
        public Store()
        {
            Products = new List<Product>();
        }

        public Store(string name)
        {        
            Name = name;
            Products = new List<Product>();
        }
    }
}
