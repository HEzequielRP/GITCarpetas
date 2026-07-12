using System.Collections.Generic;
using System.Linq;
using CuerpoSano.Context;
using CuerpoSano.Models;

namespace CuerpoSano.Services
{
    public class GR_CobranzaService
    {
        private readonly CuerpoSanoDbContext _contexto;

        public GR_CobranzaService(CuerpoSanoDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Crear(Cobranzas cobranza)
        {
            _contexto.Cobranzas.Add(cobranza);
            _contexto.SaveChanges();
        }

        public List<Cobranzas> ObtenerTodos()
        {
            return _contexto.Cobranzas.ToList();
        }

        public Cobranzas ObtenerPorId(int id)
        {
            return _contexto.Cobranzas.Find(id);
        }

        public void Actualizar(Cobranzas cobranza)
        {
            _contexto.Cobranzas.Update(cobranza);
            _contexto.SaveChanges();
        }

        public bool Eliminar(int id)
        {
            var cobranza = _contexto.Cobranzas.Find(id);
            if (cobranza == null)
            {
                return false;
            }

            _contexto.Cobranzas.Remove(cobranza);
            _contexto.SaveChanges();
            return true;
        }
    }
}