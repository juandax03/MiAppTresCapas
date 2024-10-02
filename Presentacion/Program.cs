using System;
using MiAppTresCapas.Negocio;
using MiAppTresCapas.Presentacion;
using MiAppTresCapas.Datos;
using Microsoft.EntityFrameworkCore;

namespace MiAppTresCapas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuración de la base de datos
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(@"Server=.;Database=MiAppTresCapasDB;Trusted_Connection=True;");

            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                // Inicializamos los servicios
                var clienteServicio = new ClienteServicio(context);
                var vendedorServicio = new VendedorServicio(context);
                var empresaServicio = new EmpresaServicio(context);
                var productoServicio = new ProductoServicio(context);
                var facturaServicio = new FacturaServicio(context);
                var personaServicio = new PersonaServicio(context);
                var productosPorFacturaServicio = new ProductosPorFacturaServicio(context);

                // Inicializamos las clases de presentación
                var gestionClientes = new GestionClientes(clienteServicio, empresaServicio);
                var gestionVendedores = new GestionVendedores(vendedorServicio);
                var gestionEmpresas = new GestionEmpresas(empresaServicio);
                var gestionProductos = new GestionProductos(productoServicio);
                var gestionFacturas = new GestionFacturas(facturaServicio, personaServicio, productoServicio);

                bool continuar = true;

                while (continuar)
                {
                    try
                    {
                        Console.Clear();
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("No se puede limpiar la consola: " + ex.Message);
                    }
                    Console.WriteLine("=== Menú Principal ===");
                    Console.WriteLine("1. Gestionar Clientes");
                    Console.WriteLine("2. Gestionar Vendedores");
                    Console.WriteLine("3. Gestionar Empresas");
                    Console.WriteLine("4. Gestionar Productos");
                    Console.WriteLine("5. Gestionar Facturas");
                    Console.WriteLine("6. Salir");
                    Console.Write("Seleccione una opción: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            gestionClientes.MostrarMenu();
                            break;
                        case "2":
                            gestionVendedores.MostrarMenu();
                            break;
                        case "3":
                            gestionEmpresas.MostrarMenu();
                            break;
                        case "4":
                            gestionProductos.MostrarMenu();
                            break;
                        case "5":
                            gestionFacturas.MostrarMenu();
                            break;
                        case "6":
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
}
