using NLayerApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.Interfaces
{
    public interface IProductService
    {
        void CreateProduct(ProductDTO productDTO);
        void AssignCategory(ProductDTO productDTO, CategoryDTO categoryDTO);
        ProductDTO GetProduct(int? id);
        IEnumerable<ProductDTO> GetProducts();
        void Dispose();
    }
}
