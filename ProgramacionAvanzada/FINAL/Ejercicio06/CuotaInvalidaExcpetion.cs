using System;

namespace Ejercicio06;

public class CuotaInvalidaException : Exception

{
    public CuotaInvalidaException(string mensaje) :base(mensaje)
    {
    }
}