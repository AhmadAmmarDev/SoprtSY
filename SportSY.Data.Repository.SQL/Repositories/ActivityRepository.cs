using SportSY.Core.Interfaces;
using SportSY.Core.Models;
using SportSY.Data.Repository.SQL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportSY.Data.Repository.SQL.Repositories
{
    public class ActivityRepository : SQLRepositoryBase<Activity,Activities> , IActivityRepository
    {
    }
}
