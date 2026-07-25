using System.Linq;
using System;
using System.Collections.Generic;
namespace D10_LINQ;

class Program
{
    static void Main(string[] args)
    {
        List<Adoptante> Lista=new List<Adoptante>();

        Adoptante ad1=new Adoptante(1,"Juan",2000);
        Adoptante ad2=new Adoptante(2,"Pedro",3500);
        Adoptante ad3=new Adoptante(3, "Carlos",4000);
        Adoptante ad4=new Adoptante(4,"Maria",5000);
        Adoptante ad5=new Adoptante(5, "Raquel",3000);
        Adoptante ad6=new Adoptante(6, "Ester", 1500);

        Lista.Add(ad1);
        Lista.Add(ad2);
        Lista.Add(ad3);
        Lista.Add(ad4);
        Lista.Add(ad5);
        Lista.Add(ad6);

        var mayor3000=Lista.Where(a=>a.Presupuesto>3000);
        Console.WriteLine("Adoptantes con presupuesto >3000");
        foreach (Adoptante ad in mayor3000)
        {
            Console.WriteLine($"Nombre {ad.Nombre}, Presupuesto {ad.Presupuesto}");
        }

        var ordenados=Lista.OrderByDescending(ad=>ad.Presupuesto);
        
        Console.WriteLine("Adoptantes ordenados de mayor a menor");
        foreach (Adoptante ad in ordenados)
        {
            Console.WriteLine($"Nombre {ad.Nombre}, Presupuesto {ad.Presupuesto}");
        }
        
        var nombres=Lista.Select(ad=>ad.Nombre);
        Console.WriteLine("Lista de nombres de Adoptantes");
        foreach (string nom in nombres)
        {
            Console.WriteLine($"Nombre {nom}");           
        }
        
        var mayorpresupuesto=Lista.OrderByDescending(ad=>ad.Presupuesto).FirstOrDefault();
        Console.WriteLine($"El mayor presupuesto es de {mayorpresupuesto.Nombre} por valor de {mayorpresupuesto.Presupuesto}");
        
        double promedio =Lista.Average(ad=>ad.Presupuesto);
        int mayorespromedio=Lista.Where(a=>a.Presupuesto>promedio).Count();
        Console.WriteLine($"El presupuesto promedio es {promedio}. Los adoptantes con presupuesto superior al promedio son {mayorespromedio}");
    }
}
