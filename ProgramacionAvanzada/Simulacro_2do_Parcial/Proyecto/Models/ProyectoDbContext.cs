using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Models;

public class ProyectoDbContext : DbContext
{
    public DbSet<Consultor> Consultores { get; set; }
    public DbSet<Proyecto> Proyectos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite(@"Data source=C:\Users\herod\GITCarpetas\ProgramacionAvanzada\Simulacro_2do_Parcial\Proyecto\Proyectos.db");
}
}