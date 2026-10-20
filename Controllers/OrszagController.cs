using Microsoft.AspNetCore.Mvc;
using OlimpikonokAPI.Models;
using OlimpikonokAPI.Services;

namespace OlimpikonokAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrszagController : ControllerBase
{
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        try
        {
            List<Orszag> result = new OrszagService().GetAll();
            return Ok(new OrszagService().GetAll());
        }
        catch (Exception e)
        {
            return BadRequest("Hiba a kérés végrehajtása közben: " + e.Message);
        }
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            using (var context = new OlimpikonokContext())
            {
                Orszag result = context.Orszags.FirstOrDefault(x => x.Id == id);

                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest($"Nincs ilyen azonosítójú ország ({id})!");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Hiba a kérés végrehajtása közben: " + e.Message);
        }
    }
}