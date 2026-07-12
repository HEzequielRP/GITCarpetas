using System;
using System.Dynamic;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Ejercicio1;
using System.Security.Cryptography.X509Certificates;

namespace Ejercicio1;

public class Gestionador

{
    private CarreraDbContext _context;

    public Gestionador(CarreraDbContext context)
    {
        _context = context;
    }

    public void AgregarCarrera()
    {
      var nuevaCarrera= new Carrera();  
      
      Console.WriteLine ("Ingrese nombre nueva Carrera");
      string nuevoNombre = Console.ReadLine ();
      Console.WriteLine ("Ingrese Facultad");
      string nuevaFacultad = Console.ReadLine();

      nuevaCarrera.NombreF = nuevoNombre;
      nuevaCarrera.Facultad= nuevaFacultad;

      _context.Carreras.Add(nuevaCarrera);
      _context.SaveChanges();
    }

    public void Listar ()
    {
    Console.WriteLine ("Carreras:");
    Console.WriteLine ("=========");
    var carrerasL = _context.Carreras.Include(c=>c.Estudiantes).ToList();
    foreach(var carrerasli in carrerasL)
        {
            Console.WriteLine ($"Nombre: {carrerasli.NombreF}");
            Console.WriteLine ($"Facultad: {carrerasli.Facultad}");
            Console.WriteLine ($"Cantidad de alumnos inscriptos {carrerasli.Estudiantes.Count}");
        }    
    }
    public void AgregarEstudiante()
    {
      var nuevoEstudiante= new Estudiante();  
      
      Console.WriteLine ("Ingrese nombre nuevo Estudiante");
      string nuevoNombreE = Console.ReadLine ();
      Console.WriteLine ("Ingrese apellido nuevo Estudiante");
      string nuevoApellido = Console.ReadLine();
      Console.WriteLine ("Ingrese Edad nuevo Estudiante");
      int nuevaEdad = int.Parse (Console.ReadLine());
      Console.WriteLine ("Ingrese carrera nuevo Estudiante");
      string carreraNuevoEstudiante = Console.ReadLine();
      var carerraNE = _context.Carreras
      .FirstOrDefault(c=>c.NombreF==carreraNuevoEstudiante);
      if(carerraNE==null)
        {
            Console.WriteLine("Carrera inexistente. Será creada");
            AgregarCarrera();
            carerraNE=_context.Carreras
            .FirstOrDefault(c=>c.NombreF==carreraNuevoEstudiante);
        }

        nuevoEstudiante.NombreE=nuevoNombreE;
        nuevoEstudiante.ApellidoE=nuevoApellido;
        nuevoEstudiante.Edad=nuevaEdad;
        nuevoEstudiante.CarreraE=carerraNE;
        _context.Estudiantes.Add(nuevoEstudiante);
        _context.SaveChanges();
    }
    public void Eliminar()
    {
        Console.WriteLine ("Ingrese Apellido del estudiante a eliminar");
        string ApellidoaEliminar = Console.ReadLine();
        var estudianteAEliminar = _context.Estudiantes.First(l => l.ApellidoE == ApellidoaEliminar); 
        _context.Estudiantes.Remove(estudianteAEliminar); 
        _context.SaveChanges(); 
    }
}