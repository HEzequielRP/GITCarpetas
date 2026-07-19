using System;
using System.Collections.Generic;
using Models;
namespace Ejercicio04.Models;

public class SocioGimnasio :IControlable
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

    public bool Validar()
    {
    if (string.IsNullOrEmpty(_nombre)|| CuotaBase<=0)
        {
            return false;
        }
        return true;  
    }
    public double CalcularCuotaFinal()
    {
        return _cuotaBase*1.21;
    }
}
    