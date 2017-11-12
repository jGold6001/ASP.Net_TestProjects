using OnionApp.Domain.Core;
using OnionApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Infrastructure.Business.OrderProduct
{
    public class CacheOrder : IOrder
    {
        public void MakeOrder(Product product)
        {
            //buy the product by cashe
        }
    }
}
