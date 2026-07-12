using System.Collections.Generic;

namespace Ejercicio2.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Dificultad { get; set; }
        public int CantidadJugadores { get; set; }
        public List<Sala> Salas { get; set; } = new List<Sala>();
    }
}