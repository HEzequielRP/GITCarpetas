using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Collections.Generic;
using System;

namespace Ajedrez.Models;

public class Club
{
    public int ClubId {get; set; }
    public string ClubNombre {get; set;}
    public string ClubSede {get; set;}
    public List<Jugador> ClubJugadores {get; set;}
}