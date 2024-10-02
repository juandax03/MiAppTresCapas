using System.Collections.Generic;
using System.Linq;
using MiAppTresCapas.Datos;

namespace MiAppTresCapas.Negocio
{
    public class ProductoServicio
    {
        private readonly AppDbContext _context;

        public ProductoServicio(AppDbContext context)
        {
            _context = context;
        }

        // Método para consultar todos los productos
        public List<Producto> ConsultarProductos()
        {
            return _context.Productos.ToList();
        }

        // Método para obtener un producto por su ID
        public Producto? ObtenerProductoPorId(int id)
        {
            return _context.Productos.Find(id);
        }

        // Método para guardar un nuevo producto
        public void GuardarProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
        }

        // Método para modificar un producto existente
        public void ModificarProducto(Producto producto)
        {
            _context.Productos.Update(producto);
            _context.SaveChanges();
        }

        // Método para borrar un producto
        public void BorrarProducto(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
        }
    }
}
