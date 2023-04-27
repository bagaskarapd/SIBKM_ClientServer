using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var employee = _employeeRepository.GetAll();
            return Ok(employee);
        }

        [HttpGet("ById")]
        public ActionResult GetById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }
        [HttpPost]
        public ActionResult Insert(Employee employee)
        {
            if (employee.NIK == "" || employee.NIK.ToLower() == "string")
            {
                return BadRequest("Value Cannot Be Null or Default");
            }

            var insert = _employeeRepository.insert(employee);
            if (insert > 0)
                return Ok("Insert Success");
            return BadRequest("Insert Failed");
        }

        [HttpPut]
        public ActionResult Update(Employee employee)
        {
            if (employee.NIK == "" || employee.NIK.ToLower() == "string")
                return BadRequest("Value Cannot Be Null or Default");
            {
            }

            var Update = _employeeRepository.update(employee);
            if (Update > 0)
                return Ok("Update Success");
            return BadRequest("Update Failed");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Delete = _employeeRepository.delete(id);
            if (Delete > 0)
                return Ok("Delete Success");
            return BadRequest("Delete Failed");
        }
    }
}
