using NLayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DataForTesting
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
