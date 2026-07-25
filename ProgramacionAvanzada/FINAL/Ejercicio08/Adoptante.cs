using System;
namespace Ejercicio08;

public class Adoptante
{
    public int Id;
    public string Nombre;
    public double Presupuesto;

    public static Adoptante operator + (Adoptante adoptante1, Adoptante adoptante2)
    {
        Adoptante adoptanteSuma = new Adoptante{Id=-1, Nombre=(adoptante1.Nombre+adoptante2.Nombre), Presupuesto=adoptante1.Presupuesto+adoptante2.Presupuesto};
        return adoptanteSuma;
    }
    public static bool operator > (Adoptante adoptante1, Adoptante adoptante2)
    {
        if(adoptante1.Presupuesto>adoptante2.Presupuesto)
        {
            return true;
        }
        return false;
    }
     public static bool operator < (Adoptante adoptante1, Adoptante adoptante2)
    {
        if(adoptante1.Presupuesto<adoptante2.Presupuesto)
        {
            return true;
        }
        return false;
    }
}