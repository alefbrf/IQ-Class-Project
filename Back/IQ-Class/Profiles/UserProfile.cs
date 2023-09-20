using AutoMapper;
using IQ_Class.Data.Dtos;
using IQ_Class.Models;

namespace IQ_Class.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<ChangePasswordDto, User>();
        }
    }
}
