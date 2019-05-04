using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSY.Core.Models
{
    public class Request:Model
    {
        public Guid FromPersonId { get; set; }
        public Guid ToPersonId { get; set; }
        public int? RequestTypeId { get; set; }
        public Guid? FromTeam { get; set; }
        public Guid? ToTeam { get; set; }
        public Guid? PlaceId { get; set; }
        public Guid? ActivityId { get; set; }
        public DateTime? MatchDate { get; set; }
    }
}
