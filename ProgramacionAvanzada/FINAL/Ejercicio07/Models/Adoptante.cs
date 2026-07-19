using System;
using System.Data.Common;
using System.Timers;
namespace Ejercicio07.Models;

public class Adoptante : IEntidad
{
    private int _id;
    private string _nombre;
    private double _presupuesto;
    public int Id
    {
        get {return _id;}
    }
    public string Nombre
    {
        get {return _nombre;}
        set {_nombre = value;}
    }

    public double Presupuesto
    {
        get {return _presupuesto;}
        set
        {
            if (value<0)
            {
                throw new PresupuestoInvalidoException("El presupuesto asingado no puede ser negativo"); 
            }
            _presupuesto=value;
        }
    }
    public Adoptante(int id, string nombre, double presupuesto)
    {
        _id=id;
        _nombre=nombre;
        Presupuesto = presupuesto;

    }
}