﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public UserDTO()
        {

        }
        public UserDTO(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
