﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSY.Core.Models
{
    public class Person : Model
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
    }
}
