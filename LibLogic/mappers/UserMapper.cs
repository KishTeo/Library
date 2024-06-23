using AutoMapper;
using LibDB.models;
using LibLogic.DTOs;

namespace LibLogic.mappers
{
    internal class UserMapper : Profile
    {
        public UserMapper() { CreateMap<User, UserDTO>().ReverseMap(); }
    }
}
