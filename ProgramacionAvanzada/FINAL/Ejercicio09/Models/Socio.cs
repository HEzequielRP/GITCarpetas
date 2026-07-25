using System;
using System.Data.Common;
using System.Dynamic;
namespace Ejercicio09.Models;

public abstract class Socio
{
    public int Id {get;set;}
    public string Nombre {get;set;}
    public double CuotaBase{get; set;}

    public Socio(int id, string nombre, double cuotaBase)
    {
        Id=id;
        Nombre=nombre;
        CuotaBase=cuotaBase;
    }

    public abstract double CalcularCuota();

}