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
            var existente = _contexto.Profesores.Find(entrenador.Id);
            if (existente != null)
            {
                existente.Nombre = !string.IsNullOrWhiteSpace(entrenador.Nombre) ? entrenador.Nombre : existente.Nombre;
                existente.Apellido = !string.IsNullOrWhiteSpace(entrenador.Apellido) ? entrenador.Apellido : existente.Apellido;
                existente.TipoDocumento = !string.IsNullOrWhiteSpace(entrenador.TipoDocumento) ? entrenador.TipoDocumento : existente.TipoDocumento;
                existente.NumeroDocumento = entrenador.NumeroDocumento != 0 ? entrenador.NumeroDocumento : existente.NumeroDocumento;
                existente.FechaNacimiento = entrenador.FechaNacimiento != default ? entrenador.FechaNacimiento : existente.FechaNacimiento;
                existente.TelCelular = entrenador.TelCelular != 0 ? entrenador.TelCelular : existente.TelCelular;
                existente.Direccion = !string.IsNullOrWhiteSpace(entrenador.Direccion) ? entrenador.Direccion : existente.Direccion;
                existente.Email = !string.IsNullOrWhiteSpace(entrenador.Email) ? entrenador.Email : existente.Email;
                existente.Especialidad = !string.IsNullOrWhiteSpace(entrenador.Especialidad) ? entrenador.Especialidad : existente.Especialidad;
                existente.CodigoProfesor = !string.IsNullOrWhiteSpace(entrenador.CodigoProfesor) ? entrenador.CodigoProfesor : existente.CodigoProfesor;
                existente.Certificado = entrenador.Certificado != null ? entrenador.Certificado : existente.Certificado;

                _contexto.Profesores.Update(existente);
                _contexto.SaveChanges();
            }
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
