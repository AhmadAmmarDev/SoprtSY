using System;
using System.Collections.Generic;

namespace SportSY.Data.Repository.SQL.Models
{
    public partial class PlacesTypes
    {
        public PlacesTypes()
        {
            Places = new HashSet<Places>();
        }

        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }

        public virtual ICollection<Places> Places { get; set; }
    }
}