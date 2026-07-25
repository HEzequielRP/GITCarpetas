using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Collections.Generic;
using D12_Persistencia.Models;
using Microsoft.EntityFrameworkCore;

namespace D12_Persistencia;

public class Gestionador
{
     private BibliotecaDbContext _context;

    public Gestionador(BibliotecaDbContext context)
    {
        _context = context;
    }

    public Libro CrearLibro()
    {
        Console.WriteLine("Ingrese Título");
        string titulo = Console.ReadLine();
        Console.WriteLine("Ingrese Descripción");
        string descripcion = Console.ReadLine();
        Console.WriteLine("Ingrese Fecha de Publicación");
        DateTime fechaDePublicacion = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese Id del Autor");
        int autorId = int.Parse(Console.ReadLine());
    
        var autor= _context.Autores.FirstOrDefault(a=>a.AutorId==autorId);
        if (autor==null)
        {
            Console.WriteLine("No existe ese ID. Por favor cree uno");
            autor=CrearAutor();
        }
        
        Libro nuevoLibro = new Libro()
        {Titulo=titulo, 
        Descripcion=descripcion,
        FechaDePublicacion=fechaDePublicacion,
        AutorId=autor.AutorId,
        Autor=autor};
        
        _context.LibrosDb.Add(nuevoLibro);
        _context.SaveChanges();
        
        Console.WriteLine($"Nuevo libro creado satisfactoriamente");
        return nuevoLibro;
    }
    public Autor CrearAutor()
    {
        Console.WriteLine("Ingresar Nombre");
        string nombre=Console.ReadLine();
        Console.WriteLine("Ingresar sitio web");
        string sitioweb=Console.ReadLine();

        Autor nuevoAutor = new Autor()
        {
            Nombre=nombre,
            SitioWeb=sitioweb
        };
        _context.Autores.Add(nuevoAutor);
        _context.SaveChanges();
        return nuevoAutor;
    }

    public void TraerLibrosAutor()
    {
        var librosAutor=_context.LibrosDb.Include(l=>l.Autor).ToList();
        foreach(Libro l in librosAutor)
        {
            Console.WriteLine($"Libro {l.Titulo}");
            Console.WriteLine($"Autor {l.Autor?.Nombre}");
        }
    }
    public void TraerAutorLibro()
    {
        var autorLibro = _context.Autores
        .Include(a=>a.Libros)
        .ToList();

        foreach(Autor a in autorLibro)
        {
            Console.WriteLine($"Nombre{a.Nombre}");
            Console.WriteLine($"SitioWeb{a.SitioWeb}");

            foreach(var libro in a.Libros)
            {
                Console.WriteLine($"Titulo{libro.Titulo}");
                Console.WriteLine($"Descripcion {libro.Descripcion}");
            }
        }
    }

    public void TraerLibroPorFecha()
    {
        Console.WriteLine("Ingresar año");
        int año = int.Parse(Console.ReadLine());

        var librosporfecha = _context.LibrosDb
        .Where(l => l.FechaDePublicacion.Year>año)
        .ToList();

        foreach(Libro l in librosporfecha)
        {
            Console.WriteLine($"Titulo {l.Titulo}");
            Console.WriteLine($"Descripcion {l.Descripcion}");
            Console.WriteLine($"Autor {l.Autor}");
        }
    }

    public void ActualizarLibro()
    {
        Console.WriteLine("ingresar libro a modificar");
        string libroamodificar = Console.ReadLine();

        var lam = _context.LibrosDb
        .FirstOrDefault(l=>l.Titulo==libroamodificar);

        Console.WriteLine("Ingrese nuevo título");
        string nuevotitulo = Console.ReadLine();
        lam.Titulo=nuevotitulo;

        _context.SaveChanges();
    }
}