using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.DTO
{
    public class StoreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

       
        public StoreDTO()
        {
            
        }

        public StoreDTO(string name)
        {
            Name = name;
        }
    }
}
