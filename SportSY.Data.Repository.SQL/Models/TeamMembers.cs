using System;
using System.Collections.Generic;
using System.Text;

namespace SportSY.Data.Repository.SQL.Models
{
    public class TeamMembers
    {
        public Guid TeamID { get; set; }
        public Guid PersonID { get; set; }
        public bool IsCaptin { get; set; }
    }
}
