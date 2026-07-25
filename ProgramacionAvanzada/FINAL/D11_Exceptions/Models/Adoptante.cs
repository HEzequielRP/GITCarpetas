using System;
namespace D11_Exceptions.Models;

public class Adoptante
{
    public int Id {get; set;}
    public string Nombre {get; set;}
    public int Edad {get; set;}
    public double Presupuesto {get; set;}

    public Adoptante (int id, string nombre, int edad, double presupuesto)
    {
        Id = id;
        Nombre = nombre;
        if(edad<18)
        {
            throw new EdadInvalidaException ("El adoptante no puede ser menor de 18 años");
        }
        else
        {
            Edad=edad;
        }
        if(presupuesto<=0)
        {
            throw new PresupuestoInvalidoException ("El presupuesto debe ser mayor que 0",presupuesto);
        }
        else
        {
            Presupuesto=presupuesto;
        }
    }
}