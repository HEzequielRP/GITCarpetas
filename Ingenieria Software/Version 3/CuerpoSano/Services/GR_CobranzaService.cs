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
            var existente = _contexto.Cobranzas.Find(cobranza.Id);
            if (existente != null)
            {
                existente.Fecha = cobranza.Fecha != default ? cobranza.Fecha : existente.Fecha;
                existente.Monto = cobranza.Monto != 0 ? cobranza.Monto : existente.Monto;
                existente.Pagado = cobranza.Pagado;
                existente.FormaPago = !string.IsNullOrWhiteSpace(cobranza.FormaPago) ? cobranza.FormaPago : existente.FormaPago;
                existente.MiembroId = cobranza.MiembroId != 0 ? cobranza.MiembroId : existente.MiembroId;

                _contexto.Cobranzas.Update(existente);
                _contexto.SaveChanges();
            }
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
