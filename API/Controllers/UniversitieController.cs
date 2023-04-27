using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UniversitieController : ControllerBase
{
    private readonly IUniversitieRepository _universitieRepository;
    public UniversitieController(IUniversitieRepository universitieRepository)
    {
        _universitieRepository = universitieRepository;
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        var universities = _universitieRepository.GetAll();
        return Ok(new ResponseDataVM<IEnumerable<Universitie>> {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success",
            Data = universities
        });
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
        var universities = _universitieRepository.GetById(id);
        if (universities == null)
            return NotFound(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Errors = "Id Not Found"
            });
        return Ok(new ResponseDataVM<Universitie>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success",
            Data = universities
        });
    }
    [HttpPost]
    public ActionResult Insert(Universitie universitie)
    {
        if (universitie.Name == "" || universitie.Name.ToLower() == "string") {
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Errors = "Value Cannot be Null or Default"
            });
        }

        var insert = _universitieRepository.Insert(universitie);
        if (insert > 0)
            return Ok(new ResponseDataVM<Universitie>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Insert Success",
                Data = null!
            });
        return BadRequest(new ResponseErrorsVM<string>
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Errors = "Insert Failed / Lost Connection"
        });
    }

    [HttpPut]
    public ActionResult Update(Universitie universitie)
    {
        if (universitie.Name == "" || universitie.Name.ToLower() == "string")
        {
            return BadRequest(new ResponseErrorsVM<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Errors = "Value Cannot be Null or Default"
            });
        }

        var update = _universitieRepository.Update(universitie);
        if (update > 0)
            return Ok(new ResponseDataVM<Universitie>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Update Success",
                Data = null!
            });

        return BadRequest(new ResponseErrorsVM<string>
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Errors = "Update Failed / Lost Connection"
        });
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var delete = _universitieRepository.Delete(id);
        if (delete > 0)
            return Ok(new ResponseDataVM<Universitie>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Delete Success",
                Data = null!
            });

        return BadRequest(new ResponseErrorsVM<string>
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Errors = "Delete Failed / Lost Connection"
        });
    }
}


