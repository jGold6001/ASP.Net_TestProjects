using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PushNotifyApp.Models
{
    public class BookContext : DbContext
    {
        public BookContext(string connectionString) : base(connectionString){}

        public virtual DbSet<Book> Books { get; set; }
    }
}