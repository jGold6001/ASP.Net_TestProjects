using NLayerApp.DAL.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace NLayerApp.DAL.EF
{
    public class NLayerContext : DbContext
    {
        public NLayerContext()
            : base("name=NLayerContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
    }
}