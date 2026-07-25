using System;
using System.Data.Common;
using System.Timers;
namespace D10_LINQ;

public class Adoptante
{
    public int Id {get; set;}
    public string Nombre{get;set;}
    public double Presupuesto {get;set;}

public Adoptante (int id, string nombre, double presupuesto)
    {
        Id=id;
        Nombre=nombre;
        Presupuesto=presupuesto;
    }
    
}