namespace Parciale2;
public static class PlanHelper 
{ 
public static List<Sede> LimpiarSedesDuplicadas(List<Sede> listaSedes) 
{ 
return listaSedes.GroupBy(s => s.ID).Select(g => g.First()).ToList();
} 
public static bool SonListasIdenticas(List<Sede> listaA, List<Sede> listaB) 
{ 
} 
}