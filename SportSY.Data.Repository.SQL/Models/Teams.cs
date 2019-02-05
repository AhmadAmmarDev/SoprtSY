using System;
using System.Collections.Generic;

namespace SportSY.Data.Repository.SQL.Models
{
    public partial class Teams
    {
        public Teams()
        {
            RquestFromTeamNavigation = new HashSet<Rquest>();
            RquestToTeamNavigation = new HashSet<Rquest>();
        }

        public Guid Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public virtual ICollection<Rquest> RquestFromTeamNavigation { get; set; }
        public virtual ICollection<Rquest> RquestToTeamNavigation { get; set; }
        public virtual ICollection<TeamMembers> TeamMembers { get; set; }
    }
}
