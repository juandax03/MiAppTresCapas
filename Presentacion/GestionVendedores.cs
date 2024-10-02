using System;
using MiAppTresCapas.Negocio;
using MiAppTresCapas.Datos;

namespace MiAppTresCapas.Presentacion
{
    public class GestionVendedores
    {
        private VendedorServicio _vendedorServicio;

        public GestionVendedores(VendedorServicio vendedorServicio)
        {
            _vendedorServicio = vendedorServicio;
        }

        public void CrearVendedor()
        {
            Console.WriteLine("Ingrese el nombre del vendedor:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el email del vendedor:");
            string email = Console.ReadLine();

            Console.WriteLine("Ingrese el teléfono del vendedor:");
            string telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el carnet del vendedor:");
            string carnet = Console.ReadLine();

            Console.WriteLine("Ingrese la dirección del vendedor:");
            string direccion = Console.ReadLine();

            Vendedor nuevoVendedor = new Vendedor(nombre, email, telefono, carnet, direccion);
            _vendedorServicio.IngresarVendedor(nuevoVendedor);
            Console.WriteLine("Vendedor creado exitosamente.");
        }

        public void ConsultarVendedores()
        {
            var vendedores = _vendedorServicio.ConsultarVendedores();
            Console.WriteLine("=== Lista de Vendedores ===");
            foreach (var vendedor in vendedores)
            {
                Console.WriteLine($"ID: {vendedor.Id}, Nombre: {vendedor.Nombre}, Carnet: {vendedor.Carnet}, Dirección: {vendedor.Direccion}");
            }
        }

        public void ModificarVendedor()
        {
            Console.WriteLine("Ingrese el ID del vendedor a modificar:");
            int id = int.Parse(Console.ReadLine());

            var vendedor = _vendedorServicio.ObtenerVendedorPorId(id);
            if (vendedor != null)
            {
                Console.WriteLine("Ingrese el nuevo nombre del vendedor:");
                vendedor.Nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el nuevo carnet del vendedor:");
                vendedor.Carnet = Console.ReadLine();

                Console.WriteLine("Ingrese la nueva dirección del vendedor:");
                vendedor.Direccion = Console.ReadLine();

                _vendedorServicio.ModificarVendedor(vendedor);
                Console.WriteLine("Vendedor modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Vendedor no encontrado.");
            }
        }

        public void EliminarVendedor()
        {
            Console.WriteLine("Ingrese el ID del vendedor a eliminar:");
            int id = int.Parse(Console.ReadLine());

            _vendedorServicio.BorrarVendedor(id);
            Console.WriteLine("Vendedor eliminado exitosamente.");
        }

        public void MostrarMenu()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("=== Gestión de Vendedores ===");
                Console.WriteLine("1. Crear Vendedor");
                Console.WriteLine("2. Consultar Vendedores");
                Console.WriteLine("3. Modificar Vendedor");
                Console.WriteLine("4. Eliminar Vendedor");
                Console.WriteLine("5. Volver al menú principal");

                switch (Console.ReadLine())
                {
                    case "1":
                        CrearVendedor();
                        break;
                    case "2":
                        ConsultarVendedores();
                        break;
                    case "3":
                        ModificarVendedor();
                        break;
                    case "4":
                        EliminarVendedor();
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
