using System;
using System.Collections.Generic;

namespace SportSY.Data.Repository.SQL.Models
{
    public partial class Cities
    {
        public Cities()
        {
            Places = new HashSet<Places>();
        }

        public Guid Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public Guid CountryId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Places> Places { get; set; }
    }
}
