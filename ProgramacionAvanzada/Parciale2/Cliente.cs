namespace Parciale2;
using System;

public class Cliente
{
    public string Nombre;
    public string DNI;
    public Plan PlanActual;

    public void MejorarPlan (Plan nuevoPlan)
    {
        try
        {
           PlanActual = PlanActual + nuevoPlan;
           Console.WriteLine($"Proceso exitoso"); 
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Error al intentar mejorar el plan:");
            Console.WriteLine($"Motivo: {ex.Message}");
        }
    }
    public void EsSocioPremium()
    {
        int c=0;
        foreach(Sede se in PlanActual.Sedes)
        {
            c=c+1;
        }
        if (c>1)
        {
            Console.WriteLine("socio premium");
        }
        else
        {
            Console.WriteLine ("No es socio premium");
        }
    }  
    public void MostrarEstado()
    {
        Console.WriteLine($"Nombre {Nombre}");
        Console.WriteLine($"DNI {DNI}");
        Console.WriteLine($"Plan: {PlanActual.NombrePlan}");
        Console.WriteLine($"Código del Plan {PlanActual.Codigo}");
        Console.WriteLine($"Costo:{PlanActual.Costo}");
        foreach (Sede s in PlanActual.Sedes)
        {
            Console.WriteLine($"Sede {s.Nombre}");
        }
        EsSocioPremium();
    }
}