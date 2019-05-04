using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSY.Core.Models
{
    public class Activity : Model
    {
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public int? ActivityType { get; set; }
    }
}
