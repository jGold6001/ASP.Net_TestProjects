
using OnionApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Infrastructure.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
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
