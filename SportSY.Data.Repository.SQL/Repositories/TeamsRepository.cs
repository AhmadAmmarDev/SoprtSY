using System;
using System.Collections.Generic;
using System.Text;
using SportSY.Core.Interfaces;
using SportSY.Core.Models;
using SportSY.Data.Repository.SQL.Models;

namespace SportSY.Data.Repository.SQL.Repositories
{
    public class TeamsRepository : SQLRepositoryBase<Team,Teams> , ITeamRepository
    {
    }
}
