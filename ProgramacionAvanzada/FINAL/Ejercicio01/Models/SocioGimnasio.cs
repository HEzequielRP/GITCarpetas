using System;

namespace Ejercicio01.Models;

    public class SocioGimnasio
    {
        public string _nombre { get; }
        public int _numeroSocio { get; set; }
        public double _cuotaBase { get; set; }
        
        public SocioGimnasio(string nombre, int numeroSocio, double cuotaBase)
        {
            _nombre = nombre;
            _numeroSocio = numeroSocio;
            if (cuotaBase < 0)
            {
                throw new ArgumentException("La cuota base no puede ser negativa.");
            }
            else
            {
                _cuotaBase = cuotaBase;
            }
        }
        public double CalcularCuotaFinal()
        {
            double cuotaFinal = _cuotaBase * 1.21;
            return cuotaFinal;
        }
    }