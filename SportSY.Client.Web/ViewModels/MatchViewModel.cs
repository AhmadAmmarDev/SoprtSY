using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportSY.Client.Web.ViewModels
{
    public class MatchViewModel
    {
        public string PlaceName { get; set; }
        public string AcitivityName { get; set; }
        public string FromTeam { get; set; }
        public string ToTeam { get; set; }
        public DateTime? MatchDate { get; set; }
    }
}
