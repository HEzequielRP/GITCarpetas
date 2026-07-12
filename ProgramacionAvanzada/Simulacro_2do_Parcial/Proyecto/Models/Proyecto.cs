using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Proyecto.Models;

public class Proyecto
{
    public int ProyectoId { get; set;}
    public string NombreProyecto {get; set;}
    public string Codigo {get;set;}
    public double Presupuesto {get;set;}
    public List<Consultor> ConsultorAsignado {get; set;}
}