using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace D12_Persistencia.Models;

public class Libro
{
    public int LibroId {get;set;}
    public string Titulo {get;set;}
    public string Descripcion {get;set;}
    public DateTime FechaDePublicacion {get; set;}
    public int AutorId {get; set;}
    public Autor Autor {get; set;}
}