using OnionApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Infrastructure.Data.Test.DataCollections
{
    public static class ProductsCollection
    {
        public static ICollection<Product> Products
        {
            get
            {

                return new List<Product>()
                {
                    new Product("Sumsung 22H5600", 3000),
                    new Product("Sumsung 22H5601", 3200),
                    new Product("Lenovo Vibe", 1200),
                    new Product("iPone 6", 2300)                
                };
            }
           
         }
    }
}
