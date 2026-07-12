using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Collections.Generic;
using System;
using Ajedrez.Models;

namespace Ajedrez;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddDbContext<AjedrezDbContext>(options =>
        options.UseSqlite(@"Data Source=C:\Users\herod\GITCarpetas\ProgramacionAvanzada\Simulacro_2do_Parcial\Ajedrez\Ajedrez.db"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
