    using System;
namespace D11_Exceptions.Models;

public class PresupuestoInvalidoException : Exception
{
    public double PresupuestoIntentado {get; set;}
    public PresupuestoInvalidoException(string mensaje, double presupuestoIntentado) :base(mensaje)
    {
        PresupuestoIntentado = presupuestoIntentado;
    }
}
   