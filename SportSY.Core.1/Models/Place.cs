using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSY.Core.Models
{
    public class Place : Model
    {
        public Guid? CityId { get; set; }
        public int? TypeId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
    }
}
