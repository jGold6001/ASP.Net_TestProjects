using OnionApp.Domain.Core;
using System;
using System.Data.Entity;
using System.Linq;

namespace OnionApp.Infrastructure.Data.EF
{

    public class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
    }
}