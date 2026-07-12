using Microsoft.EntityFrameworkCore;

namespace Ejercicio1.Models;
public class AdopcionDbContext : DbContext
{
    public DbSet<Animal> Animales { get; set; }
    public DbSet<Dueno> Duenos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=C:\Users\herod\GITCarpetas\ProgramacionAvanzada\SegundoParcial\Ejercicio1adopcion.db");
    }
}