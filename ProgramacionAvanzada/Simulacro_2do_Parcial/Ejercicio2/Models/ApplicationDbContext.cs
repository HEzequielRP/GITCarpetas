using Microsoft.EntityFrameworkCore;

namespace Ejercicio2.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet <Jugador> Jugadores {get; set;}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
    {
        
    }
}