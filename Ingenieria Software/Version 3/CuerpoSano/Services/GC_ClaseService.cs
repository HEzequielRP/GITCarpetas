using System.Collections.Generic;
using System.Linq;
using CuerpoSano.Context;
using CuerpoSano.Models;
using Microsoft.EntityFrameworkCore;

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
            var existente = _contexto.Clases.Find(clase.Id);
            if (existente != null)
            {
                existente.Nombre = !string.IsNullOrWhiteSpace(clase.Nombre) ? clase.Nombre : existente.Nombre;
                existente.Descripcion = !string.IsNullOrWhiteSpace(clase.Descripcion) ? clase.Descripcion : existente.Descripcion;
                existente.Horario = !string.IsNullOrWhiteSpace(clase.Horario) ? clase.Horario : existente.Horario;
                existente.CupoMaximo = clase.CupoMaximo != 0 ? clase.CupoMaximo : existente.CupoMaximo;
                existente.ProfesorId = clase.ProfesorId != 0 ? clase.ProfesorId : existente.ProfesorId;

                _contexto.Clases.Update(existente);
                _contexto.SaveChanges();
            }
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
        public string InscribirMiembro(int claseId, int miembroId)
        {
            var clase = _contexto.Clases.Include(c => c.Miembros).FirstOrDefault(c => c.Id == claseId);
            var miembro = _contexto.Miembros.Include(m => m.ListaClases).FirstOrDefault(m => m.Id == miembroId);

            if (clase == null || miembro == null) return "No se encontró la clase o el miembro.";

            if (clase.Miembros.Count >= clase.CupoMaximo)
                return "Error: La clase ya alcanzó su cupo máximo.";

            if (miembro.ListaClases.Any(c => c.Horario.Trim().ToUpper() == clase.Horario.Trim().ToUpper()))
                return "Error: El miembro ya tiene una clase en este horario.";

            clase.Miembros.Add(miembro);
            miembro.ListaClases.Add(clase);

            _contexto.SaveChanges();
            return "Inscripción exitosa.";
        }
    public List<Clase> ObtenerClases()
    {
        return _contexto.Clases
            .Include(c => c.Miembros)
            .Include(c => c.Profesor)
            .ToList();
    }
    }
}
