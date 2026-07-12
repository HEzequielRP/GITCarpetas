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
            if (miembro == null)
                throw new ArgumentNullException(nameof(miembro));

            var existente = _context.Miembros.Find(miembro.Id);
            if (existente == null)
                return null;

            ValidarMembresiaActiva(miembro.MembresiaId);
            CalcularCostosMiembro(miembro);

            existente.Nombre = miembro.Nombre;
            existente.Apellido = miembro.Apellido;
            existente.FechaNacimiento = miembro.FechaNacimiento;
            existente.Direccion = miembro.Direccion;
            existente.MembresiaId = miembro.MembresiaId;
            //existente.CostoMensual = miembro.CostoMensual;
            //existente.CostoAnual = miembro.CostoAnual;

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

           // if (!membresia.Activa)
             //   throw new InvalidOperationException("La membresía especificada no se encuentra activa.");
        }

        private void CalcularCostosMiembro(Miembro miembro)
        {
            var membresia = _context.Membresias.Find(miembro.MembresiaId);
            if (membresia == null)
                return;

            //miembro.CostoMensual = membresia.PrecioMensual;
            //miembro.CostoAnual = membresia.PrecioMensual * 12;
        }
    }
}