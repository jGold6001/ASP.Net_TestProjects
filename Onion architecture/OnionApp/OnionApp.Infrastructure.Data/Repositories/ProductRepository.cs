
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
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(DbContext context) : base(context)
        {

        }

        public Product FindByName(string name)
        {
            return FindBy(p => p.Name == name).FirstOrDefault();
        }

        public IEnumerable<Product> FindByCategory(string categoryName)
        {
            return context.Database.SqlQuery<Product>(
               "SELECT * FROM Products " +
               "JOIN Categories On Categories.Id = Products.CategoryId " +
               "AND Categories.Name = @categoryName", new SqlParameter("@categoryName", categoryName)
           ).ToList();
        }

        public IEnumerable<Product> FindByStore(string storeName)
        {
            return context.Database.SqlQuery<Product>(
               "SELECT * FROM Products " +
               "JOIN StoreProducts On StoreProducts.Product_Id = Products.Id" +
               "JOIN Stores On Stores.Id = StoreProducts.Store_Id " +
               "AND Stores.Name = @storeName", new SqlParameter("@storeName", storeName)
           ).ToList();
        }
    }
}
