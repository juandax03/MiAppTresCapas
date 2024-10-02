using MiAppTresCapas.Negocio;
using MiAppTresCapas.Datos;

namespace MiAppTresCapas.Presentacion
{
    public class GestionFacturas
    {
        private readonly FacturaServicio _facturaServicio;
        private readonly PersonaServicio _personaServicio;
        private readonly ProductoServicio _productoServicio;

        public GestionFacturas(FacturaServicio facturaServicio, PersonaServicio personaServicio, ProductoServicio productoServicio)
        {
            _facturaServicio = facturaServicio;
            _personaServicio = personaServicio;
            _productoServicio = productoServicio;
        }

        public void CrearFactura()
        {
            Console.WriteLine("Ingrese el ID de la persona asociada a la factura:");
            if (!int.TryParse(Console.ReadLine(), out int personaId))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var persona = _personaServicio.ObtenerPersonaPorId(personaId);
            if (persona == null)
            {
                Console.WriteLine("Persona no encontrada.");
                return;
            }

            Factura nuevaFactura = new Factura
            {
                Fecha = DateTime.Now,
                PersonaId = personaId,
                Persona = persona,
                Total = 0
            };

            bool agregarProductos = true;
            while (agregarProductos)
            {
                Console.WriteLine("Ingrese el ID del producto a agregar:");
                if (!int.TryParse(Console.ReadLine(), out int productoId))
                {
                    Console.WriteLine("ID de producto inválido.");
                    continue;
                }

                var producto = _productoServicio.ObtenerProductoPorId(productoId);
                if (producto == null)
                {
                    Console.WriteLine("Producto no encontrado.");
                    continue;
                }

                ProductosPorFactura productoPorFactura = new ProductosPorFactura
                {
                    Factura = nuevaFactura,
                    Producto = producto
                };

                nuevaFactura.ProductosPorFactura.Add(productoPorFactura);
                nuevaFactura.Total += producto.ValorUnitario;

                Console.WriteLine("Producto agregado exitosamente. ¿Desea agregar otro producto? (s/n):");
                agregarProductos = Console.ReadLine()?.ToLower() == "s";
            }

            _facturaServicio.GuardarFactura(nuevaFactura);
            Console.WriteLine("Factura creada exitosamente.");
        }

        public void ConsultarFacturas()
        {
            var facturas = _facturaServicio.ConsultarFacturas();
            if (!facturas.Any())
            {
                Console.WriteLine("No hay facturas registradas.");
                return;
            }

            foreach (var factura in facturas)
            {
                Console.WriteLine($"Factura ID: {factura.Id}, Fecha: {factura.Fecha}, Total: {factura.Total}, Persona: {factura.Persona?.Nombre}");
                foreach (var productoPorFactura in factura.ProductosPorFactura)
                {
                    Console.WriteLine($"\tProducto: {productoPorFactura.Producto?.Nombre}, Valor Unitario: {productoPorFactura.Producto?.ValorUnitario}");
                }
            }
        }

        public void EliminarFactura()
        {
            Console.WriteLine("Ingrese el ID de la factura a eliminar:");
            if (!int.TryParse(Console.ReadLine(), out int facturaId))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var factura = _facturaServicio.ObtenerFacturaPorId(facturaId);
            if (factura == null)
            {
                Console.WriteLine("Factura no encontrada.");
                return;
            }

            _facturaServicio.CancelarFactura(facturaId);
            Console.WriteLine("Factura eliminada exitosamente.");
        }

        public void MostrarMenu()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("=== Gestión de Facturas ===");
                Console.WriteLine("1. Crear Factura");
                Console.WriteLine("2. Consultar Facturas");
                Console.WriteLine("3. Eliminar Factura");
                Console.WriteLine("4. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        CrearFactura();
                        break;
                    case "2":
                        ConsultarFacturas();
                        break;
                    case "3":
                        EliminarFactura();
                        break;
                    case "4":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
