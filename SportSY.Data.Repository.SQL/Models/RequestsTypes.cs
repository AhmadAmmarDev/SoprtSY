using System;
using System.Collections.Generic;

namespace SportSY.Data.Repository.SQL.Models
{
    public partial class RequestsTypes
    {
        public RequestsTypes()
        {
            Rquest = new HashSet<Rquest>();
        }

        public int Id { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }

        public virtual ICollection<Rquest> Rquest { get; set; }
    }
}
