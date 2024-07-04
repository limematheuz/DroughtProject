using AutoMapper;
using DroughtProject.DTO;
using DroughtProject.Models;

namespace DroughtProject.Utils;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Users, UsersDto>();
        CreateMap<CreateUserDto, Users>();
        CreateMap<UpdateUserDto, Users>();
    }
}