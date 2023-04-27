using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountRoleController : ControllerBase
    {
        private readonly IAccountRoleRepository _accountRoleRepository;
        public AccountRoleController(IAccountRoleRepository accountRoleRepository)
        {
            _accountRoleRepository = accountRoleRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var accountRole = _accountRoleRepository.GetAll();
            return Ok(accountRole);
        }

        [HttpGet("ById")]
        public ActionResult GetById(int id)
        {
            var accountRole = _accountRoleRepository.GetById(id);
            if (accountRole == null)
                return NotFound();
            return Ok(accountRole);
        }
        [HttpPost]
        public ActionResult Insert(AccountRole accountRole)
        {
            if (accountRole.AccountNik == "" || accountRole.AccountNik.ToLower() == "string")
            {
                return BadRequest("Value Cannot Be Null or Default");
            }

            var insert = _accountRoleRepository.insert(accountRole);
            if (insert > 0)
                return Ok("Insert Success");
            return BadRequest("Insert Failed");
        }

        [HttpPut]
        public ActionResult Update(AccountRole accountRole)
        {
            if (accountRole.AccountNik == "" || accountRole.AccountNik.ToLower() == "string")
                return BadRequest("Value Cannot Be Null or Default");
            {
            }

            var Update = _accountRoleRepository.update(accountRole);
            if (Update > 0)
                return Ok("Update Success");
            return BadRequest("Update Failed");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Delete = _accountRoleRepository.delete(id);
            if (Delete > 0)
                return Ok("Delete Success");
            return BadRequest("Delete Failed");
        }
    }
}
