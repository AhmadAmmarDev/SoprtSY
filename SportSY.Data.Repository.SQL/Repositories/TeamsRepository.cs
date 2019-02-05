using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportSY.Core.Interfaces;
using SportSY.Core.Models;
using SportSY.Data.Repository.SQL.Models;

namespace SportSY.Data.Repository.SQL.Repositories
{
    public class TeamsRepository : SQLRepositoryBase<Team,Teams> , ITeamRepository
    {

        public void AddItem(Team newItem,List<Guid> TeamMemberIds)
        {
            var dbItem = Mapper.Map(newItem, new Teams());
            dbItem.Id = Guid.NewGuid();
            DB.Teams.Add(dbItem);
            var personsList = DB.Persons;
            foreach (var id in TeamMemberIds)
            {
               var person = personsList.Find(id);
                if (person != null)
                {
                  //  DB.TeamMembers.Add(dbItem.Id, person.Id);
                }
            }
           
        }
    }
}
