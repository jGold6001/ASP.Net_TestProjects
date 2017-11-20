using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; 
                                
        public ProductDTO()
        {
            
        }

        public ProductDTO(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
