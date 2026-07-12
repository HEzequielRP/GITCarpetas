using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ejercicio3;

    class Program
    {
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");

                var response = await client.GetAsync("comments?postId=1");

                string responseBody = await response.Content.ReadAsStringAsync();

                var comments = JsonSerializer.Deserialize<List<Comment>>(responseBody);

                Console.WriteLine("Cantidad de elementos: " + comments.Count);

                foreach (var comment in comments)
                {
                    Console.WriteLine(comment.name);
                }
            }
        }
    }