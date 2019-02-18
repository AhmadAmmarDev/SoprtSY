using System;
using System.Collections.Generic;

namespace SportSY.Data.Repository.SQL.Models
{
    public partial class Places
    {
        public Places()
        {
            Rquest = new HashSet<Rquest>();
        }

        public Guid Id { get; set; }
        public Guid? CityId { get; set; }
        public int? TypeId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }

        public virtual Cities City { get; set; }
        public virtual PlacesTypes Type { get; set; }
        public virtual ICollection<Rquest> Rquest { get; set; }
    }
}