using SportSY.Core.Interfaces;
using SportSY.Core.Models;

namespace SportSY.Data.SQL.Repositories
{
    public class PersonRepository:SQLRepositoryBase<Person,Persons>,IPersonRepository
    {
    }
}
