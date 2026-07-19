using System;
using System.Data.Common;
namespace Ejercicio07.Models;

public class PresupuestoInvalidoException : Exception
{
    public PresupuestoInvalidoException(string mensaje) : base(mensaje)
    {
        
    }
}