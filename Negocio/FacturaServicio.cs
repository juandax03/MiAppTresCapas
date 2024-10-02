using System.Collections.Generic;
using System.Linq;
using MiAppTresCapas.Datos;

namespace MiAppTresCapas.Negocio
{
    public class FacturaServicio
    {
        private readonly AppDbContext _context;

        public FacturaServicio(AppDbContext context)
        {
            _context = context;
        }

        public List<Factura> ConsultarFacturas()
        {
            return _context.Facturas.ToList();
        }

        public Factura? ObtenerFacturaPorId(int id)
        {
            return _context.Facturas.Find(id);
        }

        public void GuardarFactura(Factura factura)
        {
            _context.Facturas.Add(factura);
            _context.SaveChanges();
        }

        public void ModificarFactura(Factura factura)
        {
            _context.Facturas.Update(factura);
            _context.SaveChanges();
        }

        public void CancelarFactura(int id)
        {
            var factura = _context.Facturas.Find(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
                _context.SaveChanges();
            }
        }
    }
}
