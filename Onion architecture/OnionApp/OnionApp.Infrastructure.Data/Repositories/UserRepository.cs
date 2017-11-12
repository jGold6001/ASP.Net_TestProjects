
using OnionApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Infrastructure.Data.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(DbContext context) : base(context)
        {

        }

        public User FindByName(string name)
        {
            return FindBy(u => u.Name==name).FirstOrDefault();
        }
    }
}
