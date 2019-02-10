using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportSY.Core.Models;

namespace SportSY.Core.Interfaces
{
    public interface ITeamRepository : IRepository<Team>
    {
        void AddItem(Team newItem, List<Guid> TeamMemberIds, Guid CaptinId);


        List<Guid> GetPendingMembershipByPersonID(Guid personId);
    }
}
