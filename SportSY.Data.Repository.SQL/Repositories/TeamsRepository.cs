using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportSY.Core.Interfaces;
using SportSY.Core.Models;
using SportSY.Data.Repository.SQL.Models;

namespace SportSY.Data.Repository.SQL.Repositories
{
    public class TeamsRepository : SQLRepositoryBase<Team, Teams>, ITeamRepository
    {

        public void AddItem(Team newItem, List<Guid> TeamMemberIds, Guid CaptinId)
        {
            var dbItem = Mapper.Map(newItem, new Teams());
            dbItem.Id = Guid.NewGuid();
            DB.Teams.Add(dbItem);
            foreach (var memberId in TeamMemberIds)
            {
                DB.TeamMembers.Add(new TeamMembers() { PersonID = memberId, TeamID = dbItem.Id, RequestStatusID = (int)RequestStatus.Pending, IsCaptin = false });
            }
            DB.TeamMembers.Add(new TeamMembers() { PersonID = CaptinId, TeamID = dbItem.Id, RequestStatusID = (int)RequestStatus.Pending, IsCaptin = true });

            DB.SaveChanges();
            //DB.Teams.Add(dbItem);
            //var personsList = DB.Persons;
            //foreach (var id in TeamMemberIds)
            //{
            //   var person = personsList.Find(id);
            //    if (person != null)
            //    {
            //      //  DB.TeamMembers.Add(dbItem.Id, person.Id);
            //    }
            //}

        }

        public List<Guid>  GetPendingMembershipByPersonID(Guid personId)
        {
            List<Guid> result = null;
            if(personId != null)
            {
                 result = DB.TeamMembers.Where(e => e.PersonID == personId && e.RequestStatusID == (int)RequestStatus.Pending).Select(e => e.TeamID).ToList();
            }
            return result;
        }
    }
}
