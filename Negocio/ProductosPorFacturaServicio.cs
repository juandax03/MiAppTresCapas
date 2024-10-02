using System.Collections.Generic;
using System.Linq;
using MiAppTresCapas.Datos;

namespace MiAppTresCapas.Negocio
{
    public class ProductosPorFacturaServicio
    {
        private readonly AppDbContext _context;

        public ProductosPorFacturaServicio(AppDbContext context)
        {
            _context = context;
        }

        public List<ProductosPorFactura> ConsultarProductosPorFactura()
        {
            return _context.ProductosPorFacturas.ToList();
        }

        public ProductosPorFactura? ObtenerProductoPorFacturaPorId(int id)
        {
            return _context.ProductosPorFacturas.Find(id);
        }

        public void GuardarProductoPorFactura(ProductosPorFactura productoPorFactura)
        {
            _context.ProductosPorFacturas.Add(productoPorFactura);
            _context.SaveChanges();
        }

        public void ModificarProductoPorFactura(ProductosPorFactura productoPorFactura)
        {
            _context.ProductosPorFacturas.Update(productoPorFactura);
            _context.SaveChanges();
        }

        public void BorrarProductoPorFactura(int id)
        {
            var productoPorFactura = _context.ProductosPorFacturas.Find(id);
            if (productoPorFactura != null)
            {
                _context.ProductosPorFacturas.Remove(productoPorFactura);
                _context.SaveChanges();
            }
        }
    }
}
