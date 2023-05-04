using API.Base;
using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : GeneralController<IEmployeeRepository, Employee, string>
    {
        public EmployeeController(IEmployeeRepository repository) : base(repository) { }
        [HttpPost("Register")]
        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var login = _repository.Login(loginVM);
            if (login)
            {
                return Ok(new ResponseDataVM<string>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Login Success",
                });
            }
            return NotFound(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Errors = "Login Failed / account or password not found"
            });
        }

        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            var register = _repository.Register(registerVM);
            if (register > 0)
            {
                return Ok(new ResponseDataVM<string>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Insert Success",
                });
            }
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Errors = "Insert Failed / Lost Connection"
            });
        }
    }
}