using System;
using System.Collections.Generic;

namespace SportSY.Data.Repository.SQL.Models
{
    public partial class Activities
    {
        public Activities()
        {
            Rquest = new HashSet<Rquest>();
        }

        public Guid Id { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public int? ActivityType { get; set; }

        public virtual ActivityTypes ActivityTypeNavigation { get; set; }
        public virtual ICollection<Rquest> Rquest { get; set; }
    }
}