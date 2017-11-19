using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Registration { get; set; }

        public User()
        {

        }

        public User(string name, int age, DateTime registration)
        {
            Registration = registration;
            Name = name;
            Age = age;
        }
    }
}
