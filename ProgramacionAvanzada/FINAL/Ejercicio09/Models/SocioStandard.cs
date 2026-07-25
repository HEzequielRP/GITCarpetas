using System;
using System.Data.Common;
using System.Dynamic;
namespace Ejercicio09.Models;

public class SocioStandard : Socio
{
  public SocioStandard (int id, string nombre, double cuotaBase) : base(id, nombre, cuotaBase)
    {
        
    }

    public override double CalcularCuota()
    {
        return CuotaBase;
    }
}