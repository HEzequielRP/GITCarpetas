using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Collections.Generic;
using System;

namespace Ajedrez.Models;

public class Jugador
{
    public int JugadorId {get; set; }
    public string JugadorNombre {get; set;}
    public int JugadorRankingFide {get; set;}
    public string JugadorCategoria {get; set;}
    public int ClubId {get; set;}
    public Club? JugadorClub {get; set; }

}