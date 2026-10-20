using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlimpikonokAPI.DTOs;
using OlimpikonokAPI.Models;

namespace OlimpikonokAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SportoloController : Controller
{
    [HttpGet("OrszagSportag")]
    public IActionResult GetOrszagSportag()
    {
        try
        {
            using (var context = new OlimpikonokContext())
            {
                List<SportoloOrszagSportagDTO> result = new OlimpikonokContext().Sportolos.Include(s => s.Orszag)
                    .Include(s => s.Sportag).Select(s => new SportoloOrszagSportagDTO()
                    {
                        Id = s.Id,
                        Nev = s.Nev,
                        OrszagNev = s.Orszag.Nev,
                        SportagNev = s.Sportag.Megnevezes
                    }).ToList();
                
                return Ok(result);
            }
        }
        catch (Exception e)
        {
            return BadRequest("Hiba történt: " +  e.Message);
        }
    }
}