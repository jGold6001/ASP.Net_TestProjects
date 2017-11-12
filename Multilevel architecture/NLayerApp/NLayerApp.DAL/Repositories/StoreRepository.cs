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
    public class StoreRepository : Repository<Store>
    {
        public StoreRepository(DbContext context) : base(context)
        {

        }

        public Store FindByName(string name)
        {
            return FindBy(s => s.Name == name).FirstOrDefault();
        }

        public List<Store> FindByProduct(string productName)
        {
            return context.Database.SqlQuery<Store>(
                "SELECT * FROM Stores " +
                "JOIN StoreProducts On Stores.Id = StoreProducts.Store_Id " +
                "JOIN Products On StoreProducts.Product_Id = Products.Id " +
                "AND Products.Name = @productName", new SqlParameter("@productName", productName)
            ).ToList();
        }

    }
}
