using Microsoft.EntityFrameworkCore;
using Ejercicio2.Models;

namespace Ejercicio2.Models
{
    public class EscapeRoomDbContext : DbContext
    {
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public EscapeRoomDbContext(DbContextOptions<EscapeRoomDbContext> options) : base(options)
        {
        }
    }
}