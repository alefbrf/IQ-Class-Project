using AutoMapper;
using IQ_Class.Data;
using IQ_Class.Data.Dtos;
using IQ_Class.Models;
using IQ_Class.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IQ_Class.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        private SchoolService _schoolService;
        private IMapper _mapper;

        public SchoolController(SchoolService schoolService, IMapper mapper)
        {
            _schoolService = schoolService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<int> CreateSchool()
        {
            var newSchool = _schoolService.Create();

            return CreatedAtAction(nameof(GetSchool), new { id = newSchool.Id }, newSchool);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetSchool(int id) 
        {
            var school = _schoolService.Get(id);

            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdatePartialSchool(int id,[FromBody] JsonPatchDocument<UpdateSchoolDto> patch)
        {
            var school = _schoolService.Get(id);

            if (school == null)
            {
                return NotFound();
            }

            var schoolUpdate = _mapper.Map<UpdateSchoolDto>(school);

            patch.ApplyTo(schoolUpdate, ModelState);

            if (!TryValidateModel(schoolUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(schoolUpdate, school);

            school = _schoolService.Update(schoolUpdate, school);

            return Ok(school);
        }
    }
}
