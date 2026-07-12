using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Collections.Generic;
using System;
using Ajedrez.Models;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.HttpResults;


namespace Ajedrez.Controllers;

[ApiController]
[Route("[controller]")]
public class AjedrezController : ControllerBase
{
    private readonly AjedrezDbContext _context;
     public AjedrezController(AjedrezDbContext context)
    {
        _context=context;
    }
    [HttpGet("jugadores")]
    public ActionResult<List<Jugador>> Get()
    {
        var jugador = _context.Jugadores.Include(c=>c.JugadorClub).ToList();
        return Ok(jugador);
    }

    [HttpPost("jugadores")]
    public ActionResult Post (Jugador nuevojugador)
    {
        if(nuevojugador.JugadorRankingFide==0 || nuevojugador.JugadorRankingFide== 3000)
        {
            return BadRequest ("El Ranking FIDE debe estar entre 0 y 3000");
        }
        var clubExiste = _context.Clubes.Any(c=>c.ClubId==nuevojugador.ClubId);
        if(!clubExiste)
        {
            return BadRequest("El club no existe");
        }
        _context.Jugadores.Add(nuevojugador);
        _context.SaveChanges();
        return Ok(nuevojugador);
    }
     public ActionResult<Jugador> GetbyId(int id)
    {
        var jugador=_context.Jugadores.FirstOrDefault(j=> j.JugadorId == id);
        if (jugador == null)
        {
           return NotFound(); 
        }
        return Ok(jugador);
    }
    [HttpPut("jugadores/{id}")]
    public ActionResult PutJugador (int id, Jugador jugadoreditado)
    {
        if(id !=jugadoreditado.JugadorId )
        {
            return BadRequest("El ID del jugador no coincide con el de la URL");
        }
        var existe = _context.Jugadores.Any(j=>j.JugadorId==id);
        if(!existe)
        {
            return NotFound("el jugador solicitado no existe");
        }
        _context.Entry(jugadoreditado).State=EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }
    [HttpGet("clubes/{clubId}/jugadores")]
    public ActionResult GetJugadoresporClub(int clubId)
    {
       var jugadores = _context.Jugadores
       .Where(j=>j.ClubId==clubId)
       .ToList();
       if(jugadores.Count==0)
        {
            return NotFound("No se encontraron jugadores pare el club especificado");
        }
        return Ok(jugadores); 
    }
    [HttpDelete("jugadores/{id}")]
    public ActionResult DeleteJugador(int id)
    {
        var jugador=_context.Jugadores.Find(id);

        if(jugador==null)
        {
            return NotFound("El jugador solicitado no existe");
        }
        _context.Jugadores.Remove(jugador);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPost("clubes")]
    public ActionResult PostClub(Club nuevoClub)
    {
        _context.Clubes.Add(nuevoClub);
        _context.SaveChanges();
        return Ok(nuevoClub);
    }
    /*private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }*/
}
