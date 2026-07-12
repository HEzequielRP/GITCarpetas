using System.Collections.Generic;
using System.Linq;
using CuerpoSano.Context;
using CuerpoSano.Models;

namespace CuerpoSano.Services
{
    public class GP_MembresiaService
    {
        private readonly CuerpoSanoDbContext _contexto;

        public GP_MembresiaService(CuerpoSanoDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Crear(Membresia membresia)
        {
            _contexto.Membresias.Add(membresia);
            _contexto.SaveChanges();
        }

        public List<Membresia> ObtenerTodos()
        {
            return _contexto.Membresias.ToList();
        }

        public Membresia ObtenerPorId(int id)
        {
            return _contexto.Membresias.Find(id);
        }

        public void Actualizar(Membresia membresia)
        {
            _contexto.Membresias.Update(membresia);
            _contexto.SaveChanges();
        }

        public bool Eliminar(int id)
        {
            var membresia = _contexto.Membresias.Find(id);
            if (membresia == null)
            {
                return false;
            }

            _contexto.Membresias.Remove(membresia);
            _contexto.SaveChanges();
            return true;
        }
    }
}