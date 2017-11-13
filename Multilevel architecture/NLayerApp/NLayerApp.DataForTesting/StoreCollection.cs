using NLayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DataForTesting
{
    public static class StoreCollection
    { 
        public static ICollection<Store> Stores
        {
            get
            {
                return new List<Store>()
                {
                    new Store("Rozetka"),
                    new Store("MobiDick")
                };
            }
        }
    }
}
