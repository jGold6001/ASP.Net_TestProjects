using NLayerApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.Interfaces
{
    public interface IStoreService
    {
        void AddOrUpdateProduct(ProductDTO product);
        ProductDTO GetProduct(int? id);
        IEnumerable<ProductDTO> GetProducts();
        void Dispose();
    }
}
