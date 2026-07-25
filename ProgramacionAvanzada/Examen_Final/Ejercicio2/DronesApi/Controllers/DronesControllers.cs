using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DronesApi.Data;
using DronesApi.Models;

namespace DronesApi.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class DronesController : ControllerBase
    {
        private readonly DronesDbContext _context;

        public DronesController(DronesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Dron>> Listar()
        {
            var drones = _context.Drones.ToList();
            return Ok(drones);
        }

        [HttpPost]
        public ActionResult<Dron> Crear(Dron dron)
        {
            _context.Drones.Add(dron);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Listar), new { id = dron.DronId }, dron);
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var dron = _context.Drones.FirstOrDefault(d => d.DronId == id);
            if (dron == null)
                return NotFound();

            _context.Drones.Remove(dron);
            _context.SaveChanges();
            return NoContent();
        }
    }
