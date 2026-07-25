using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace D12_Persistencia.Models;

public class BibliotecaDbContext : DbContext
{
    public DbSet <Autor> Autores {get; set;}
    public DbSet <Libro> LibrosDb {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data source=C:\Users\herod\GITCarpetas\ProgramacionAvanzada\FINAL\D12_Persistencia\db.sqlite3");

    }
}