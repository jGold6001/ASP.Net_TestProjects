using NLayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(DbContext context) : base(context)
        {

        }

        public Category FindByName(string name)
        {
            return FindBy(c => c.Name == name).FirstOrDefault();
        }

    }
}
