using System;
using System.Collections.Generic;
namespace Ejercicio01V2.Models;

public class SocioGimnasio
{
    private int _numeroSocio;
    private string _nombre;
    private double _cuotaBase;

    public int NumeroSocio
    {
        get{return _numeroSocio;}
        set{_numeroSocio = value;}        
    }
    public string Nombre
    {
        get{return _nombre;}
    }
    public double CuotaBase
    {
        get{return _cuotaBase;}
        set
        {
            if(value <=0)
            {
                throw new ArgumentException("La cuota base debe ser mayor a cero.");
            }
            else
            {
                _cuotaBase = value;
            }
        }
    }

    public SocioGimnasio(int numeroSocio, string nombre, double cuotaBase)
    {
        _numeroSocio = numeroSocio;
        _nombre = nombre;
        CuotaBase = cuotaBase;
    }

    public double CalcularCuotaFinal()
    {
        return _cuotaBase*1.21;
    }
}
    