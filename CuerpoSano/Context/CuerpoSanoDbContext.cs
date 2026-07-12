using System;
using Microsoft.EntityFrameworkCore;
using CuerpoSano.Context;
using CuerpoSano.Models;

namespace CuerpoSano.Context
{
    public class CuerpoSanoDbContext : DbContext
    {
         public CuerpoSanoDbContext(DbContextOptions<CuerpoSanoDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Membresia> Membresias { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Cobranzas> Cobranzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=cuerposano.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar herencia TPH para Persona
            modelBuilder.Entity<Persona>()
                .HasDiscriminator<string>("TipoPersona")
                .HasValue<Miembro>("Miembro")
                .HasValue<Profesor>("Profesor");

            // Relación Profesor - Clases (uno a muchos)
            modelBuilder.Entity<Profesor>()
                .HasMany(p => p.Clases)
                .WithOne(c => c.Profesor)
                .HasForeignKey(c => c.ProfesorId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación Clases - Miembro (muchos a muchos)
            modelBuilder.Entity<Clase>()
                .HasMany(c => c.Miembros)
                .WithMany(m => m.ListaClases)
                .UsingEntity(j => j.ToTable("ClasesMiembros"));

            // Relación Cobranzas - Miembro (uno a muchos)
            modelBuilder.Entity<Cobranzas>()
                .HasOne(c => c.Miembro)
                .WithMany(m => m.Cobranzas)
                .HasForeignKey(c => c.MiembroId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Miembro - Membresia (muchos a uno)
            modelBuilder.Entity<Miembro>()
                .HasOne(m => m.Membresia)
                .WithMany()
                .HasForeignKey(m => m.MembresiaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}