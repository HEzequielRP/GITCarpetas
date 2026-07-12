using Microsoft.EntityFrameworkCore;

namespace Servidor1.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Pelicula> peliculas {get; set;}
}