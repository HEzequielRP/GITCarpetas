using Microsoft.EntityFrameworkCore;
using DronesApi.Models;

namespace DronesApi.Data;

    public class DronesDbContext : DbContext
    {
        public DbSet<Dron> Drones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=drones.db");
        }
    }
