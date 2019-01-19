using System;
using System.Collections.Generic;

namespace SportSY.Data.Repository.SQL.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Cities = new HashSet<Cities>();
        }

        public Guid Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }

        public virtual ICollection<Cities> Cities { get; set; }
    }
}
