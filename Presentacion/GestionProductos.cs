using System;
using MiAppTresCapas.Negocio;
using MiAppTresCapas.Datos;

namespace MiAppTresCapas.Presentacion
{
    public class GestionProductos
    {
        private ProductoServicio _productoServicio;

        public GestionProductos(ProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        public void CrearProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el valor unitario del producto:");
            decimal valorUnitario = decimal.Parse(Console.ReadLine());

            Producto nuevoProducto = new Producto(nombre, valorUnitario);
            _productoServicio.GuardarProducto(nuevoProducto);
            Console.WriteLine("Producto creado exitosamente.");
        }

        public void ConsultarProductos()
        {
            var productos = _productoServicio.ConsultarProductos();
            Console.WriteLine("=== Lista de Productos ===");
            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Nombre}, Valor Unitario: {producto.ValorUnitario}");
            }
        }

        public void ModificarProducto()
        {
            Console.WriteLine("Ingrese el ID del producto a modificar:");
            int id = int.Parse(Console.ReadLine());

            var producto = _productoServicio.ObtenerProductoPorId(id);
            if (producto != null)
            {
                Console.WriteLine("Ingrese el nuevo nombre del producto:");
                producto.Nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el nuevo valor unitario del producto:");
                producto.ValorUnitario = decimal.Parse(Console.ReadLine());

                _productoServicio.ModificarProducto(producto);
                Console.WriteLine("Producto modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void EliminarProducto()
        {
            Console.WriteLine("Ingrese el ID del producto a eliminar:");
            int id = int.Parse(Console.ReadLine());

            _productoServicio.BorrarProducto(id);
            Console.WriteLine("Producto eliminado exitosamente.");
        }

        public void MostrarMenu()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("=== Gestión de Productos ===");
                Console.WriteLine("1. Crear Producto");
                Console.WriteLine("2. Consultar Productos");
                Console.WriteLine("3. Modificar Producto");
                Console.WriteLine("4. Eliminar Producto");
                Console.WriteLine("5. Volver al menú principal");

                switch (Console.ReadLine())
                {
                    case "1":
                        CrearProducto();
                        break;
                    case "2":
                        ConsultarProductos();
                        break;
                    case "3":
                        ModificarProducto();
                        break;
                    case "4":
                        EliminarProducto();
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }
    }
}
