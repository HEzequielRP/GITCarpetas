namespace RpgCombate;

class Program
{
    static void Main(string[] args)
    {
        List<Personaje> equipo = new List<Personaje>
        {
            new Guerrero("Guts", 120, 15),
            new Mago("Gandalf", 80, 30),
            new Guerrero("Kratos", 150, 12)
        };

        Batalla batalla = new Batalla();
        batalla.IniciarCombate(equipo, 3);
    }
}