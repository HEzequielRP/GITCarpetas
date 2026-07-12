using Ejercicio2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio2.Controllers;

[ApiController]
[Route("[controller]")]
public class SalaController : ControllerBase
{
    private EscapeRoomDbContext _context;

    public SalaController(EscapeRoomDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Sala>> Get()
    {
        return Ok(_context.Salas.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<Sala> GetbyId(int id)
    {
        var sala = _context.Salas.FirstOrDefault(s => s.SalaId == id);
        if (sala == null)
        {
            return NotFound();
        }
        return Ok(sala);
    }

    [HttpPost]
    public ActionResult Post(Sala sala)
    {
        _context.Salas.Add(sala);
        _context.SaveChanges();
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var sala = _context.Salas.FirstOrDefault(s => s.SalaId == id);
        if (sala == null)
        {
            return NotFound();
        }
        _context.Salas.Remove(sala);
        _context.SaveChanges();
        return NoContent();
    }
}