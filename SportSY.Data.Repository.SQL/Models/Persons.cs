﻿using System;
using System.Collections.Generic;

namespace SportSY.Data.Repository.SQL.Models
{
    public partial class Persons
    {
        public Persons()
        {
            Users = new HashSet<Users>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
