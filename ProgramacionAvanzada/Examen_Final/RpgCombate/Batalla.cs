namespace RpgCombate;

    public class Batalla
    {
        public void IniciarCombate(List<Personaje> Equipo, int iteraciones)
        {
            int dañoTotal = 0;

            for (int i = 0; i < iteraciones; i++)
            {
                Console.WriteLine($"\n--- Iteración {i + 1} ---");

                foreach (Personaje personaje in Equipo)
                {
                    int daño = personaje.Atacar();
                    dañoTotal += daño;
                    Console.WriteLine($"{personaje.Nombre} causó {daño} de daño");
                }
            }

            Console.WriteLine($"\n=== Daño total acumulado: {dañoTotal} ===");
        }
    }
