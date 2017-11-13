using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.BusinessModels
{
    public class Discount
    {
        public decimal Value {
            get; private set;
        }
        public Discount(decimal value)
        {
            this.Value = value;
        }
       
        public decimal GetDiscountedPrice(decimal sum)
        {
            if (DateTime.Now.Day == 1)
                return sum - sum * Value;
            return sum;
        }
    }
}
