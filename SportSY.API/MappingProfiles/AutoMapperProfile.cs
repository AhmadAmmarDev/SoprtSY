using AutoMapper;
using SportSY.API.Models;
using SportSY.Core.Models;


namespace SportSY.API.MappingProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}
