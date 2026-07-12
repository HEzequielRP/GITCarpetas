
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Ejercicio1.Models;

    public class Animal
    {
        public int AnimalId { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }
        public float Peso { get; set; }
        public string Nombre { get; set; }
        public int? DuenoId { get; set; }
        public Dueno Dueno { get; set; }
    }
