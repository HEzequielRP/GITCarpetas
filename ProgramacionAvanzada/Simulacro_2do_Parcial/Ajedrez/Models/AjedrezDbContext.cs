using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Collections.Generic;
using System;

namespace Ajedrez.Models;

public class AjedrezDbContext : DbContext
{
    public AjedrezDbContext(DbContextOptions<AjedrezDbContext>options):base(options)
    {
        
    }
    public DbSet<Club> Clubes {get ; set;}
    public DbSet<Jugador> Jugadores {get ; set; }
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
{ 
optionsBuilder.UseSqlite(@"Data Source=C:\Users\herod\GITCarpetas\ProgramacionAvanzada\Simulacro_2do_Parcial\Ajedrez\Ajedrez.db"); 
} 

}