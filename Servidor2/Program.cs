namespace Servidor2;

class Program
{
    static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args); //crea un objeto aplicación web a través de un constructor.
        
        WebApplication app = builder.Build();
        app.Use(async (context, next) =>
        {
           Console.WriteLine("Solicitud recibida");
           await next(); 
        });
        app.Run(async context =>
        {
            await context.Response.WriteAsync("Hola mundo!");
        });
        app.Run();
    }
}
