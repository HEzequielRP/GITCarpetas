using System;
using System.Dynamic;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Ejercicio1;

namespace Ejercicio1;

public class CarreraDbContext : DbContext
{
    public DbSet<Carrera> Carreras {get; set;}
    public DbSet<Estudiante> Estudiantes {get ; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    {

        optionsBuilder.UseSqlite(@"Data source=C:\Users\herod\GITCarpetas\ProgramacionAvanzada\Simulacro_2do_Parcial\Ejercicio1\db.sqlite3");

    }

}

