using System.Collections.Generic;
using System.Linq;
using CuerpoSano.Context;
using CuerpoSano.Models;

namespace CuerpoSano.Services
{
    public class GE_EntrenadorService
    {
        private readonly CuerpoSanoDbContext _contexto;

        public GE_EntrenadorService(CuerpoSanoDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Crear(Profesor entrenador)
        {
            _contexto.Profesores.Add(entrenador);
            _contexto.SaveChanges();
        }

        public List<Profesor> ObtenerTodos()
        {
            return _contexto.Profesores.ToList();
        }

        public Profesor ObtenerPorId(int id)
        {
            return _contexto.Profesores.Find(id);
        }

        public void Actualizar(Profesor entrenador)
        {
            _contexto.Profesores.Update(entrenador);
            _contexto.SaveChanges();
        }

        public bool Eliminar(int id)
        {
            var entrenador = _contexto.Profesores.Find(id);
            if (entrenador == null)
            {
                return false;
            }

            _contexto.Profesores.Remove(entrenador);
            _contexto.SaveChanges();
            return true;
        }
    }
}