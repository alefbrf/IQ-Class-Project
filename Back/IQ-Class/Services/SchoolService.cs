using AutoMapper;
using IQ_Class.Data;
using IQ_Class.Data.Dtos;
using IQ_Class.Models;

namespace IQ_Class.Services
{
    public class SchoolService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public SchoolService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public School Create()
        {
            var newSchool = new School();

            _context.schools.Add(newSchool);

            _context.SaveChanges();

            return newSchool;
        }

        public School? Get(int id)
        {
            var school = _context.schools.FirstOrDefault(school => school.Id == id);

            return school;
        }

        public School? Update(UpdateSchoolDto updateSchoolDto, School school)
        {
            if (school == null || updateSchoolDto == null) 
            {
                return null;
            }

            _mapper.Map(updateSchoolDto, school);
            _context.Update(school);
            _context.SaveChanges();

            return school;
        }
    }
}
