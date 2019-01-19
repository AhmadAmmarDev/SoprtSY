using System;
using System.Collections.Generic;

namespace SportSY.Data.Repository.SQL.Models
{
    public partial class Roles
    {
        public Roles()
        {
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            RoleClaims = new HashSet<RoleClaims>();
        }

        public string Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<RoleClaims> RoleClaims { get; set; }
    }
}
