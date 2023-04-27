using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationRepository _educationRepository;
        public EducationController(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var education = _educationRepository.GetAll();
            return Ok(education);
        }

        [HttpGet("ById")]
        public ActionResult GetById(int id)
        {
            var education = _educationRepository.GetById(id);
            if (education == null)
                return NotFound();
            return Ok(education);
        }
        [HttpPost]
        public ActionResult Insert(Education education)
        {
            if (education.Major == "" || education.Major.ToLower() == "string")
            {
                return BadRequest("Value Cannot Be Null or Default");
            }

            var insert = _educationRepository.insert(education);
            if (insert > 0)
                return Ok("Insert Success");
            return BadRequest("Insert Failed");
        }

        [HttpPut]
        public ActionResult Update(Education education)
        {
            if (education.Major == "" || education.Major.ToLower() == "string")
                return BadRequest("Value Cannot Be Null or Default");
            {
            }

            var Update = _educationRepository.update(education);
            if (Update > 0)
                return Ok("Update Success");
            return BadRequest("Update Failed");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Delete = _educationRepository.delete(id);
            if (Delete > 0)
                return Ok("Delete Success");
            return BadRequest("Delete Failed");
        }
    }
}
