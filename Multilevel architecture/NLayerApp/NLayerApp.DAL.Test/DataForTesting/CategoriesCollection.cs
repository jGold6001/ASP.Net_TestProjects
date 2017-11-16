using NLayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DataForTesting
{
    public static class CategoriesCollection
    {
        public static ICollection<Category> Categories
        {
            get
            {
                return new List<Category>()
                {
                    new Category("Mobile phone"),
                    new Category("Smart TV")
                };
            }
        }
    }
}
