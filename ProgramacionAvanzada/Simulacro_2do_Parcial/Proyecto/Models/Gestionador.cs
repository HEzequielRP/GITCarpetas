using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
using SQLitePCL;
using System.Linq;

namespace Proyecto.Models;

public class Gestionador
{
    private ProyectoDbContext _context;

    public Gestionador(ProyectoDbContext context)
    {
        _context = context;
    }

    public void AgregarProyecto()
    {
        var NuevoProyecto = new Proyecto();
        Console.WriteLine ("Agregar Nombre del proyecto");
        string NombreProyectoNuevo= Console.ReadLine();
        Console.WriteLine ("Agregar Codigo del proyecto");
        string CodigoNuevo=Console.ReadLine();
        Console.WriteLine ("Agregar Presupuesto del proyecto");
        double PresupuestoNuevo=double.Parse (Console.ReadLine());
        if (PresupuestoNuevo<0)
        {
            Console.WriteLine("El presupuesto no puede ser negativo");
        }
        else
        {
            NuevoProyecto.NombreProyecto = NombreProyectoNuevo;
            NuevoProyecto.Codigo=CodigoNuevo;
            NuevoProyecto.Presupuesto=PresupuestoNuevo;

            _context.Proyectos.Add(NuevoProyecto);
            _context.SaveChanges();
        }
    }

    public void ListarProyectos()
    {
        var ProyectosListar = _context.Proyectos.Include(c=>c.ConsultorAsignado).ToList();
        foreach (var Proyectoslistar in ProyectosListar)
        {
            double CostoTotal = Proyectoslistar.ConsultorAsignado.Sum(c=>c.TarifaHora);
            Console.WriteLine($"ID del proyecto: {Proyectoslistar.ProyectoId}");
            Console.WriteLine($"Nombre del proyecto: {Proyectoslistar.NombreProyecto}");
            Console.WriteLine($"Codigo del proyecto: {Proyectoslistar.Codigo}");
            Console.WriteLine($"Presupuesto del proyecto: {Proyectoslistar.Presupuesto}");
            Console.WriteLine($"Consultores Asignados: ");
            foreach (var con in Proyectoslistar.ConsultorAsignado)
            {
                Console.WriteLine($"-{con.NombreConsultor}");
            }
            Console.WriteLine($"Costo total {CostoTotal}");
        }
    }

    public void AsignarConsultor()
    {
        
        Console.WriteLine("Ingrese código para asingar consultores");
        string NombreProyectoAsignar = Console.ReadLine();
        var proyectoAsignar =_context.Proyectos.FirstOrDefault(p=>p.NombreProyecto==NombreProyectoAsignar);
        if (proyectoAsignar != null)
        {
            Consultor nuevoConsultor = new Consultor();
            Console.WriteLine ("Ingrese nombre");
            string nombreconsultor=Console.ReadLine();
            Console.WriteLine ("Ingrese Especialidad"); 
            string especialidadconsultor=Console.ReadLine();
            Console.WriteLine ("Ingrese Tarifa por hora");
            double tarifaconsultor = double.Parse(Console.ReadLine());

            nuevoConsultor.NombreConsultor = nombreconsultor;
            nuevoConsultor.Especialidad=especialidadconsultor;
            nuevoConsultor.TarifaHora=tarifaconsultor;
            nuevoConsultor.ProyectoAsignado = proyectoAsignar;

            _context.Consultores.Add(nuevoConsultor);
            _context.SaveChanges();
            
        }



    }
    public void BuscarConsultoresPorEspecialidad()
    {
        var ConsultorListar = _context.Consultores.Include(c=>c.ProyectoAsignado).ToList();
        Console.WriteLine("Ingrese Especialidad");
        string especialidadListar= Console.ReadLine();

        foreach (var consultorListar in ConsultorListar )
        {
            if (consultorListar.Especialidad == especialidadListar)
            {
                Console.WriteLine($"Consultor: {consultorListar.NombreConsultor}");
                if(consultorListar.ProyectoAsignado!=null)
                {
                Console.WriteLine($"Proyecto asignado {consultorListar.ProyectoAsignado.NombreProyecto}");
                }
            }
        }
    }
    public void FinalizarProyecto()
    {
        Console.WriteLine("Ingrese proyecto a borrar");
        int proyectoIdBorrar=int.Parse(Console.ReadLine());
        var proyectoFinalizar =_context.Proyectos.FirstOrDefault(p=>p.ProyectoId==proyectoIdBorrar);

        if (proyectoFinalizar.ProyectoId != null)
        {
            _context.Proyectos.Remove(proyectoFinalizar);
            _context.SaveChanges();
        }


        
    }

}
