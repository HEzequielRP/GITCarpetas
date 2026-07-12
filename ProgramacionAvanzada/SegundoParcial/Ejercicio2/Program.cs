using Ejercicio2.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddDbContext<EscapeRoomDbContext>(options =>
            options.UseSqlite("Data source=escaperoom.db"));

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}