using System;
using System.Data.Common;
using System.Timers;
namespace Ejercicio07.Models;

public class Contenedor<T>
{
    public T Valor;
    public Contenedor<T> SiguienteNodo;
}