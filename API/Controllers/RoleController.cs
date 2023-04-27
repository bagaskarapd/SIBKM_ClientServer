using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var roles = _roleRepository.GetAll();
            return Ok(roles);
        }

        [HttpGet("ById")]
        public ActionResult GetById(int id)
        {
            var roles = _roleRepository.GetById(id);
            if (roles == null)
                return NotFound();
            return Ok(roles);
        }
        [HttpPost]
        public ActionResult Insert(Role role)
        {
            if (role.Name == "" || role.Name.ToLower() == "string")
            {
                return BadRequest("Value Cannot Be Null or Default");
            }

            var insert = _roleRepository.insert(role);
            if (insert > 0)
                return Ok("Insert Success");
            return BadRequest("Insert Failed");
        }

        [HttpPut]
        public ActionResult Update(Role role)
        {
            if (role.Name == "" || role.Name.ToLower() == "string")
                return BadRequest("Value Cannot Be Null or Default");
            {
            }

            var Update = _roleRepository.update(role);
            if (Update > 0)
                return Ok("Update Success");
            return BadRequest("Update Failed");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Delete = _roleRepository.delete(id);
            if (Delete > 0)
                return Ok("Delete Success");
            return BadRequest("Delete Failed");
        }
    }
}
