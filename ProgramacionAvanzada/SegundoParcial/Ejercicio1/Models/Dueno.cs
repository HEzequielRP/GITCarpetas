using System.Collections.Generic;

namespace Ejercicio1.Models;
public class Dueno
{
    public int DuenoId { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public List<Animal> Animales { get; set; } = new List<Animal>();
}