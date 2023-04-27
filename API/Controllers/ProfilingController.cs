using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilingController : ControllerBase
    {
        private readonly IProfilingRepository _profilingRepository;
        public ProfilingController(IProfilingRepository profilingRepository)
        {
            _profilingRepository = profilingRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var profilings = _profilingRepository.GetAll();
            return Ok(profilings);
        }

        [HttpGet("ById")]
        public ActionResult GetById(string id)
        {
            var profilings = _profilingRepository.GetById(id);
            if (profilings == null)
                return NotFound();
            return Ok(profilings);
        }
        [HttpPost]
        public ActionResult Insert(Profiling profiling)
        {
            if (profiling.EmployeeNIK == "" || profiling.EmployeeNIK.ToLower() == "string")
            {
                return BadRequest("Value Cannot Be Null or Default");
            }

            var insert = _profilingRepository.insert(profiling);
            if (insert > 0)
                return Ok("Insert Success");
            return BadRequest("Insert Failed");
        }

        [HttpPut]
        public ActionResult Update(Profiling profiling)
        {
            if (profiling.EmployeeNIK == "" || profiling.EmployeeNIK.ToLower() == "string")
                return BadRequest("Value Cannot Be Null or Default");
            {
            }

            var Update = _profilingRepository.update(profiling);
            if (Update > 0)
                return Ok("Update Success");
            return BadRequest("Update Failed");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var Delete = _profilingRepository.delete(id);
            if (Delete > 0)
                return Ok("Delete Success");
            return BadRequest("Delete Failed");
        }
    }
}
