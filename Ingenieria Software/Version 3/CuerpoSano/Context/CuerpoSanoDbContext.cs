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

            modelBuilder.Entity<Persona>()
                .HasDiscriminator<string>("TipoPersona")
                .HasValue<Miembro>("Miembro")
                .HasValue<Profesor>("Profesor");

            modelBuilder.Entity<Profesor>()
                .HasMany(p => p.Clases)
                .WithOne(c => c.Profesor)
                .HasForeignKey(c => c.ProfesorId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Clase>()
                .HasMany(c => c.Miembros)
                .WithMany(m => m.ListaClases)
                .UsingEntity(j => j.ToTable("ClasesMiembros"));

            modelBuilder.Entity<Cobranzas>()
                .HasOne(c => c.Miembro)
                .WithMany(m => m.Cobranzas)
                .HasForeignKey(c => c.MiembroId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Miembro>()
                .HasOne(m => m.Membresia)
                .WithMany()
                .HasForeignKey(m => m.MembresiaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}