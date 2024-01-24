using AutoMapper;
using MinimalApiWithJwt.Models;

namespace MinimalApiWithJwt.Profiles
{
    public class UserCredentialsProfile : Profile
    {
        public UserCredentialsProfile()
        {
            CreateMap<UserRegisterDTO, UserDTO>();
            CreateMap<UserDTO, UserWithoutPasswordDTO>();
        }
    }
}
