using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Ejercicio1;
    class Program
    {
        static async Task Main(string[] args)
        {
            // Instanciamos el objeto Comment de manera simple
            var nuevoComment = new Comment
            {
                postId = 1,
                name = "Juan Perez",
                email = "juan.perez@example.com",
                body = "Este es un comentario de prueba enviado desde un cliente C#."
            };

            // Creamos el cliente HTTP garantizando la liberación de recursos con using
            using (var client = new HttpClient())
            {
                // Establecemos la URI base de la API
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");

                // Serializamos el objeto y creamos el cuerpo de la solicitud
                var content = JsonContent.Create(nuevoComment);

                // Enviamos la solicitud POST al endpoint "comments"
                var response = await client.PostAsync("comments", content);

                // Mostramos el código de estado de la respuesta (nombre y valor numérico)
                Console.WriteLine($"Código de retorno de la respuesta a la solicitud POST: {Convert.ToInt32(response.StatusCode)} ({response.StatusCode})");

                // Leemos y mostramos el contenido JSON recibido
                var respuestaCadena = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Contenido recibido:");
                Console.WriteLine(respuestaCadena);
            }
        }
    }