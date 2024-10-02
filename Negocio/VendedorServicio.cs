using System.Collections.Generic;
using System.Linq;
using MiAppTresCapas.Datos;

namespace MiAppTresCapas.Negocio
{
    public class VendedorServicio
    {
        private readonly AppDbContext _context;

        public VendedorServicio(AppDbContext context)
        {
            _context = context;
        }

        public List<Vendedor> ConsultarVendedores()
        {
            return _context.Vendedores.ToList();
        }

        public Vendedor? ObtenerVendedorPorId(int id)
        {
            return _context.Vendedores.Find(id);
        }

        public void IngresarVendedor(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
        }

        public void ModificarVendedor(Vendedor vendedor)
        {
            _context.Vendedores.Update(vendedor);
            _context.SaveChanges();
        }

        public void BorrarVendedor(int id)
        {
            var vendedor = _context.Vendedores.Find(id);
            if (vendedor != null)
            {
                _context.Vendedores.Remove(vendedor);
                _context.SaveChanges();
            }
        }
    }
}
