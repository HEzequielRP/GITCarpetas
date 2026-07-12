using Ejercicio2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio2.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private EscapeRoomDbContext _context;

    public CategoriaController(EscapeRoomDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Categoria>> Get()
    {
        return Ok(_context.Categorias.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<Categoria> GetbyId(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
        if (categoria == null)
        {
            return NotFound();
        }
        return Ok(categoria);
    }

    [HttpPost]
    public ActionResult Post(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        _context.SaveChanges();
        return Ok();
    }
}