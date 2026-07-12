using System.Collections.Generic;
using System.Linq;
using CuerpoSano.Context;
using CuerpoSano.Models;

namespace CuerpoSano.Services
{
    public class GC_ClaseService
    {
        private readonly CuerpoSanoDbContext _contexto;

        public GC_ClaseService(CuerpoSanoDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Crear(Clase clase)
        {
            _contexto.Clases.Add(clase);
            _contexto.SaveChanges();
        }

        public List<Clase> ObtenerTodos()
        {
            return _contexto.Clases.ToList();
        }

        public Clase ObtenerPorId(int id)
        {
            return _contexto.Clases.Find(id);
        }

        public void Actualizar(Clase clase)
        {
            _contexto.Clases.Update(clase);
            _contexto.SaveChanges();
        }

        public bool Eliminar(int id)
        {
            var clase = _contexto.Clases.Find(id);
            if (clase == null)
            {
                return false;
            }

            _contexto.Clases.Remove(clase);
            _contexto.SaveChanges();
            return true;
        }
    }
}