namespace Ejercicio2.Models
{
    public class Sala
    {
        public int SalaId { get; set; }
        public string Nombre { get; set; }
        public string Tematica { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}