using AutoMapper;
using IQ_Class.Data.Dtos;
using IQ_Class.Models;

namespace IQ_Class.Profiles
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile() 
        {
            CreateMap<UpdateSchoolDto, School>();
            CreateMap<School, UpdateSchoolDto>();
        }
    }
}
