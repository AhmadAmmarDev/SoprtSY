using System;
using System.Collections.Generic;
using System.Text;

namespace SportSY.Data.Repository.SQL.Models
{
    public class TeamMembers
    {
        public Guid TeamID { get; set; }
        public Teams Team { get; set; }
        public Guid PersonID { get; set; }
        public Persons Person { get; set; }
        public bool IsCaptin { get; set; }

        public int RequestStatusID { get;set; }
    }
}
