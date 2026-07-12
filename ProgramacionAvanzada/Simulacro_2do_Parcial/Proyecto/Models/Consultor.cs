using System;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Models;

public class Consultor
{
    public int ConsultorId {get; set;}
    public string NombreConsultor {get; set;}
    public string Especialidad {get;set;}
    public double TarifaHora {get;set;}
    public int ProyectoId {get; set;} 
    public Proyecto ProyectoAsignado {get; set; }
}