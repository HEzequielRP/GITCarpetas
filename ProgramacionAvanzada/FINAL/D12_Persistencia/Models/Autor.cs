using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Collections.Generic;

namespace D12_Persistencia.Models;

public class Autor
{
    public int AutorId {get;set;}
    public string Nombre {get; set;}
    public string SitioWeb {get;set;}
    public List<Libro> Libros {get;set;}
}