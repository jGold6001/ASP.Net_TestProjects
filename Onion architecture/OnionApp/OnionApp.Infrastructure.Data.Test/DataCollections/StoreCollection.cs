using OnionApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Infrastructure.Data.Test.DataCollections
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
