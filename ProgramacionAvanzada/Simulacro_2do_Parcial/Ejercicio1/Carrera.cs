using System;
using System.Dynamic;
using System.Collections.Generic;

namespace Ejercicio1;

public class Carrera
{
    public int CarreraId {get; set;}
    public string NombreF {get; set;}
    public string Facultad {get;set;}
    public List<Estudiante> Estudiantes {get;set;}
}