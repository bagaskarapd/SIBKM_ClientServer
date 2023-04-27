using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var account = _accountRepository.GetAll();
            return Ok(account);
        }

        [HttpGet("ById")]
        public ActionResult GetById(int id)
        {
            var account = _accountRepository.GetById(id);
            if (account == null)
                return NotFound();
            return Ok(account);
        }
        [HttpPost]
        public ActionResult Insert(Account account)
        {
            if (account.EmployeeNIK == "" || account.EmployeeNIK.ToLower() == "string")
            {
                return BadRequest("Value Cannot Be Null or Default");
            }

            var insert = _accountRepository.insert(account);
            if (insert > 0)
                return Ok("Insert Success");
            return BadRequest("Insert Failed");
        }

        [HttpPut]
        public ActionResult Update(Account account)
        {
            if (account.EmployeeNIK == "" || account.EmployeeNIK.ToLower() == "string")
                return BadRequest("Value Cannot Be Null or Default");
            {
            }

            var Update = _accountRepository.update(account);
            if (Update > 0)
                return Ok("Update Success");
            return BadRequest("Update Failed");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Delete = _accountRepository.delete(id);
            if (Delete > 0)
                return Ok("Delete Success");
            return BadRequest("Delete Failed");
        }
    }
}
