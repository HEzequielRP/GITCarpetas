using System.Text;
using System.Text.Json;
using DronesClient.Models;

string url = "http://localhost:5003/api/drones";
var client = new HttpClient();

Console.WriteLine("=== CLIENTE DE GESTIÓN DE DRONES ===");

Console.WriteLine("Agregando drones...");
var dron1 = new Dron { Modelo = "Phantom 4", Marca = "DJI", AutonomiaMinutos = 30 };
var dron2 = new Dron { Modelo = "Mavic 3", Marca = "DJI", AutonomiaMinutos = 45 };

string json1 = JsonSerializer.Serialize(dron1);
var content1 = new StringContent(json1, Encoding.UTF8, "application/json");
var response1 = client.PostAsync(url, content1).Result;

string json2 = JsonSerializer.Serialize(dron2);
var content2 = new StringContent(json2, Encoding.UTF8, "application/json");
var response2 = client.PostAsync(url, content2).Result;

Console.WriteLine($"Dron 1 creado: {(int)response1.StatusCode}");
Console.WriteLine($"Dron 2 creado: {(int)response2.StatusCode}");

Console.WriteLine("Listado completo:");
var responseGet = client.GetAsync(url).Result;
string jsonResponse = responseGet.Content.ReadAsStringAsync().Result;
var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
var drones = JsonSerializer.Deserialize<List<Dron>>(jsonResponse, options);

if (drones != null)
{
    foreach (var dron in drones)
        Console.WriteLine($"  [{dron.DronId}] {dron.Marca} {dron.Modelo} - {dron.AutonomiaMinutos}min");
}

int idEliminar = drones?.FirstOrDefault()?.DronId ?? 0;
Console.WriteLine($"Eliminando dron Id {idEliminar}...");
var responseDelete = client.DeleteAsync($"{url}/{idEliminar}").Result;
Console.WriteLine($"Codigo: {(int)responseDelete.StatusCode}");

Console.WriteLine("Listado despues de eliminar:");
var responseGet2 = client.GetAsync(url).Result;
string jsonResponse2 = responseGet2.Content.ReadAsStringAsync().Result;
var drones2 = JsonSerializer.Deserialize<List<Dron>>(jsonResponse2, options);

if (drones2 != null)
{
    foreach (var dron in drones2)
        Console.WriteLine($"  [{dron.DronId}] {dron.Marca} {dron.Modelo} - {dron.AutonomiaMinutos}min");
}

Console.WriteLine("=== FIN ===");
