
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
            var existente = _contexto.Membresias.Find(membresia.Id);
            if (existente != null)
            {
                existente.Nombre = !string.IsNullOrWhiteSpace(membresia.Nombre) ? membresia.Nombre : existente.Nombre;
                existente.Precio = membresia.Precio != 0 ? membresia.Precio : existente.Precio;
                existente.DuracionDias = membresia.DuracionDias != 0 ? membresia.DuracionDias : existente.DuracionDias;
                existente.Publico = !string.IsNullOrWhiteSpace(membresia.Publico) ? membresia.Publico : existente.Publico;

                _contexto.Membresias.Update(existente);
                _contexto.SaveChanges();
            }
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
