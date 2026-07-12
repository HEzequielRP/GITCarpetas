using System;
using System.Collections.Generic;
using System.Linq;
using CuerpoSano.Context;
using CuerpoSano.Models;
using Microsoft.EntityFrameworkCore;

namespace CuerpoSano.Services
{
    public class GM_MiembroService
    {
        private readonly CuerpoSanoDbContext _context;

        public GM_MiembroService(CuerpoSanoDbContext context)
        {
            _context = context;
        }

        public Miembro CrearMiembro(Miembro miembro)
        {
            if (miembro == null)
                throw new ArgumentNullException(nameof(miembro));

            ValidarMembresiaActiva(miembro.MembresiaId);
            CalcularCostosMiembro(miembro);

            _context.Miembros.Add(miembro);
            _context.SaveChanges();
            return miembro;
        }

        public List<Miembro> ObtenerMiembros()
        {
            return _context.Miembros
                .AsNoTracking()
                .Include(m => m.Membresia)
                .Include(m=>m.ListaClases)
                .ToList();
        }

        public Miembro ObtenerMiembroPorId(int id)
        {
            return _context.Miembros
                .Include(m => m.Membresia)
                .FirstOrDefault(m => m.Id == id);
        }

        public Miembro ActualizarMiembro(Miembro miembro)
        {
            var existente = _context.Miembros.Find(miembro.Id);
            if (existente == null) return null;

            existente.Nombre = !string.IsNullOrWhiteSpace(miembro.Nombre) ? miembro.Nombre : existente.Nombre;
            existente.Apellido = !string.IsNullOrWhiteSpace(miembro.Apellido) ? miembro.Apellido : existente.Apellido;
            existente.TipoDocumento = !string.IsNullOrWhiteSpace(miembro.TipoDocumento) ? miembro.TipoDocumento : existente.TipoDocumento;
            existente.NumeroDocumento = miembro.NumeroDocumento != 0 ? miembro.NumeroDocumento : existente.NumeroDocumento;
            existente.FechaNacimiento = miembro.FechaNacimiento != default ? miembro.FechaNacimiento : existente.FechaNacimiento;
            existente.TelCelular = miembro.TelCelular != 0 ? miembro.TelCelular : existente.TelCelular;
            existente.Direccion = !string.IsNullOrWhiteSpace(miembro.Direccion) ? miembro.Direccion : existente.Direccion;
            existente.Email = !string.IsNullOrWhiteSpace(miembro.Email) ? miembro.Email : existente.Email;
            existente.Telefono = !string.IsNullOrWhiteSpace(miembro.Telefono) ? miembro.Telefono : existente.Telefono;
            existente.CodigoAlumno = !string.IsNullOrWhiteSpace(miembro.CodigoAlumno) ? miembro.CodigoAlumno : existente.CodigoAlumno;
            existente.MembresiaId = miembro.MembresiaId != 0 ? miembro.MembresiaId : existente.MembresiaId;

            _context.Miembros.Update(existente);
            _context.SaveChanges();
            return existente;
        }

        public bool EliminarMiembro(int id)
        {
            var miembro = _context.Miembros.Find(id);
            if (miembro == null)
                return false;

            _context.Miembros.Remove(miembro);
            _context.SaveChanges();
            return true;
        }

        private void ValidarMembresiaActiva(int membresiaId)
        {
            var membresia = _context.Membresias.Find(membresiaId);
            if (membresia == null)
                throw new InvalidOperationException("La membresía especificada no existe.");

        }

        private void CalcularCostosMiembro(Miembro miembro)
        {
            var membresia = _context.Membresias.Find(miembro.MembresiaId);
            if (membresia == null)
                return;

        }
        public Miembro ObtenerConDetalle(int id)
        {
            return _context.Miembros
                .Include(m => m.ListaClases)
                .Include(m => m.Membresia)
                .FirstOrDefault(m => m.Id == id);
        }
    }
    
}
