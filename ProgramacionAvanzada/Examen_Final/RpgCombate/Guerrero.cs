namespace RpgCombate;

    public class Guerrero : Personaje
    {
        private int _fuerza;

        public Guerrero(string nombre, int puntosVida, int fuerza)
            : base(nombre, puntosVida)
        {
            _fuerza = fuerza;
        }

        public override int Atacar()
        {
            return _fuerza * 2;
        }
    }
