using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportSY.Core.Interfaces;
using SportSY.Core.Models;
using SportSY.Data.Repository.SQL.Models;

namespace SportSY.Data.Repository.SQL.Repositories
{
    public class UserRepository : SQLRepositoryBase<User, Users>, IUserRepository
    {
        private IMapper _mapper;
        public UserRepository()
        {
            var mappingConfiguration = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<User, Users>();
                cfg.CreateMap<Users, User>();
                cfg.CreateMap<Persons, Person>();
            });
            Mapper mapper = new Mapper(mappingConfiguration);
            MapperConfiguration = mappingConfiguration;
            _mapper = mapper;
        }
        public override IEnumerable<User> GetItems()
        {
            var dbItem = DB.Users.Include(e => e.Person).ToList();
            IEnumerable<User> modelItmes = new List<User>();
            return modelItmes = _mapper.Map<IEnumerable<User>>(dbItem);
        }
    }
}
