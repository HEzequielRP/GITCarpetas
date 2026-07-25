using System;
namespace D11_Exceptions.Models;

public class EdadInvalidaException : Exception
{

    public EdadInvalidaException(string mensaje) :base(mensaje)
    {
    }
}