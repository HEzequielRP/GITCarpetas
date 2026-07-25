namespace RpgCombate;

    public class Mago : Personaje
    {
        private int _mana;

        public Mago(string nombre, int puntosVida, int mana)
            : base(nombre, puntosVida)
        {
            _mana = mana;
        }

        public override int Atacar()
        {
            if (_mana >= 10)
            {
                _mana -= 10;
                return 20;
            }
            else
            {
                return 5;
            }
        }
    }
