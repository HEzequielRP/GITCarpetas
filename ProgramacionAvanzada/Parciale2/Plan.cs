namespace Parciale2;
using System;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

public class Plan
{
    public string NombrePlan;
    public string Codigo;
    public double Costo;
    public List<Sede> Sedes = new List<Sede>();

    public void MostrarDetalles()
    {
        Console.WriteLine($"Nombre del plan {NombrePlan}, Código: {Codigo}, Costo: {Costo} ");
        foreach (Sede S in Sedes)
        {
            Console.WriteLine($"Sede disponible: {S.Nombre}");
        }
    }

    public static Plan operator + (Plan P1, Plan P2)
    {
        if (P1.Codigo.Contains("PACK"))
        {
            throw new InvalidOperationException($"Plan no válido. El plan {P1.NombrePlan} ya es un combo");
        }
        if (P2.Codigo.Contains("PACK"))
        {
            throw new InvalidOperationException($"Plan no válido. El plan {P2.NombrePlan} ya es un combo");
        }         
        Plan PlanCombinado = new Plan();
        PlanCombinado.Codigo="PACK"+P1.Codigo+P2.Codigo;
        PlanCombinado.NombrePlan=P1.NombrePlan+ " y"+ P2.NombrePlan;
        PlanCombinado.Costo=(P1.Costo+P2.Costo)*0.20;
        //PlanCombinado.Sedes= P1.Sedes.Concat(P2.Sedes).ToList();
        foreach (Sede SC in P1.Sedes)
        {
            PlanCombinado.Sedes.Add(SC);
        }
                foreach (Sede SC in P2.Sedes)
        {
            PlanCombinado.Sedes.Add(SC);
        }

    }
}