using System;
using System.Collections.Generic;

namespace SportSY.Data.Repository.SQL.Models
{
    public partial class ActivityTypes
    {
        public ActivityTypes()
        {
            Activities = new HashSet<Activities>();
        }

        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }

        public virtual ICollection<Activities> Activities { get; set; }
    }
}
