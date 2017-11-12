using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Domain.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Store> Stores { get; set; }

        public Product()
        {
            Stores = new List<Store>();
        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
            Stores = new List<Store>();
        }
    }
}
