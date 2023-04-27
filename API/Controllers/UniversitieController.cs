using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        return Ok(universities);
    }

    [HttpGet("ById")]
    public ActionResult GetById(int id)
    {
        var universities = _universitieRepository.GetById(id);
        if (universities == null)
            return NotFound();
        return Ok(universities);
    }
    [HttpPost]
    public ActionResult Insert(Universitie universitie)
    {
        if (universitie.Name == "" || universitie.Name.ToLower() == "string") {
            return BadRequest("Value Cannot Be Null or Default");
        }

        var insert = _universitieRepository.Insert(universitie);
        if (insert > 0)
            return Ok("Insert Success");
        return BadRequest("Insert Failed");
    }

    [HttpPut]
    public ActionResult Update(Universitie universitie)
    {
        if (universitie.Name == "" || universitie.Name.ToLower() == "string")
            return BadRequest("Value Cannot Be Null or Default"); {
        }

        var Update = _universitieRepository.Update(universitie);
        if (Update > 0)
            return Ok("Update Success");
        return BadRequest("Update Failed");
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var delete = _universitieRepository.Delete(id);
        if (delete > 0)
            return Ok("Delete Success");
        return BadRequest("Delete Failed");
    }
}


