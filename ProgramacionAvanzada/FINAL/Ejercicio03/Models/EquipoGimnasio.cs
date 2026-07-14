using System;

namespace Ejercicio03.Models;

public class EquipoGimnasio
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Peso { get; set; }

  public static EquipoGimnasio operator +(EquipoGimnasio equipo1, EquipoGimnasio equipo2)
    {
        if (equipo1.Peso <= 0|| equipo2.Peso <= 0)
        {
            throw new InvalidOperationException("Equipos Inválidos para Combinación");
        }
        else
        {
            EquipoGimnasio equipoCombinado = new EquipoGimnasio
            {
                Nombre = $"{equipo1.Nombre} + {equipo2.Nombre}",
                Tipo = $"{equipo1.Tipo} + {equipo2.Tipo}",
                Peso = equipo1.Peso + equipo2.Peso
            };
            return equipoCombinado;
        }
    }

}