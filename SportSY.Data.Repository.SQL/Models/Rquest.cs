using System;
using System.Collections.Generic;

namespace SportSY.Data.Repository.SQL.Models
{
    public partial class Rquest
    {
        public Guid Id { get; set; }
        public Guid FromPersonId { get; set; }
        public Guid ToPersonId { get; set; }
        public int? RequestTypeId { get; set; }
        public Guid? FromTeam { get; set; }
        public Guid? ToTeam { get; set; }
        public Guid? PlaceId { get; set; }
        public Guid? ActivityId { get; set; }
        public DateTime? MatchDate { get; set; }

        public virtual Activities Activity { get; set; }
        public virtual Teams FromTeamNavigation { get; set; }
        public virtual Places Place { get; set; }
        public virtual RequestsTypes RequestType { get; set; }
        public virtual Teams ToTeamNavigation { get; set; }
    }
}
