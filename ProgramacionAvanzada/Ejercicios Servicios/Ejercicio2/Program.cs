using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ejercicio2;

    class Program
    {
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                // Establecemos la URI base de la API
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");

                // Realizamos la solicitud GET al endpoint "comments"
                var response = await client.GetAsync("comments");

                // Leemos el cuerpo de la respuesta como una cadena de texto (JSON)
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserializamos el JSON recibido a una lista de objetos Comment
                var comments = JsonSerializer.Deserialize<List<Comment>>(responseBody);

                // Imprimimos por consola el nombre de los primeros cinco comentarios
                for (int i = 0; i < 5 && i < comments.Count; i++)
                {
                    Console.WriteLine(comments[i].name);
                }
            }
        }
    }
