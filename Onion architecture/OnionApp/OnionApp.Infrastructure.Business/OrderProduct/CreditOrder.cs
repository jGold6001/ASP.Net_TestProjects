using OnionApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionApp.Domain.Core;

namespace OnionApp.Infrastructure.Business.OrderProduct
{
    public class CreditOrder : IOrder
    {
        public void MakeOrder(Product product)
        {
            //buy the product by credit
        }
    }
}
