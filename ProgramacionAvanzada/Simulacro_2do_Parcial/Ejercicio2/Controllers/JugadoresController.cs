using Ejercicio2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio2.Controllers;

[ApiController]
[Route("[controller]")]
public class JugadoresController : ControllerBase
{
    private ApplicationDbContext _context;
    public JugadoresController(ApplicationDbContext context)
    {
        _context=context;
    }
    [HttpGet]
    public ActionResult<List<Jugador>> Get()
    {
        return Ok (_context.Jugadores.ToList());
    }
    [HttpGet("{id}")]
    public ActionResult<Jugador> GetbyId(int id)
    {
        var jugador=_context.Jugadores.FirstOrDefault(j=> j.Id == id);
        if (jugador == null)
        {
           return NotFound(); 
        }
        return Ok(jugador);
    }

    [HttpPost]
    public ActionResult post(Jugador jugador)
    {
        _context.Jugadores.Add(jugador);
        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id}")]

    public ActionResult Delete(int id)
    {
        var jugador=_context.Jugadores.FirstOrDefault(j=> j.Id == id);
        if (jugador == null)
        {
           return NotFound(); 
        }
        _context.Jugadores.Remove(jugador);
        _context.SaveChanges();

        return NoContent();
    } 
}
