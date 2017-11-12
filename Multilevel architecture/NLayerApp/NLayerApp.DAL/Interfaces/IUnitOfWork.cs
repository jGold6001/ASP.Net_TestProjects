using NLayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<Store> Stores { get; }
        void Save();
    }
}
