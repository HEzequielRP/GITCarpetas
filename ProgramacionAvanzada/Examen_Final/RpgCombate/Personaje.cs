namespace RpgCombate;

    public abstract class Personaje
    {
        public string Nombre { get; set; }
        public int PuntosVida { get; set; }

        public Personaje(string nombre, int puntosVida)
        {
            Nombre = nombre;
            PuntosVida = puntosVida;
        }

        public abstract int Atacar();
    }
