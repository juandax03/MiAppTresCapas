using System;
using MiAppTresCapas.Negocio;
using MiAppTresCapas.Datos;

namespace MiAppTresCapas.Presentacion
{
    public class GestionClientes
    {
        private ClienteServicio _clienteServicio;
        private EmpresaServicio _empresaServicio;

        public GestionClientes(ClienteServicio clienteServicio, EmpresaServicio empresaServicio)
        {
            _clienteServicio = clienteServicio;
            _empresaServicio = empresaServicio;
        }

public void CrearCliente()
{
    try
    {
        Console.WriteLine("Ingrese el nombre del cliente:");
        string? nombre = Console.ReadLine();
        
        Console.WriteLine("Ingrese el email del cliente:");
        string? email = Console.ReadLine();
        
        Console.WriteLine("Ingrese el teléfono del cliente:");
        string? telefono = Console.ReadLine();
        
        Console.WriteLine("Ingrese el crédito del cliente:");
        if (!decimal.TryParse(Console.ReadLine(), out decimal credito))
        {
            Console.WriteLine("Crédito inválido. Usando 0 como valor.");
            credito = 0;
        }
        
        Empresa? empresa = null;
        Console.WriteLine("¿Desea asociar una empresa? (s/n):");
        string asociarEmpresa = Console.ReadLine()?.ToLower();
        
        if (asociarEmpresa == "s")
        {
            Console.WriteLine("Ingrese el ID de la empresa:");
            if (int.TryParse(Console.ReadLine(), out int empresaId))
            {
                empresa = _empresaServicio.ObtenerEmpresaPorId(empresaId);
                
                if (empresa == null)
                {
                    Console.WriteLine("Error: La empresa con ese ID no existe. El cliente no será asociado a ninguna empresa.");
                }
            }
            else
            {
                Console.WriteLine("ID de empresa inválido. El cliente no será asociado a ninguna empresa.");
            }
        }
        
        Cliente nuevoCliente;
        if (empresa != null)
        {
            nuevoCliente = new Cliente(nombre, email, telefono, credito, empresa);
        }
        else
        {
            nuevoCliente = new Cliente(nombre, email, telefono, credito);
        }

        _clienteServicio.AgregarCliente(nuevoCliente);
        Console.WriteLine("Cliente creado exitosamente.");
    }
    catch (ArgumentNullException ex)
    {
        Console.WriteLine("Error al crear el cliente: " + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error inesperado: " + ex.Message);
    }
}


        public void ConsultarClientes()
        {
            var clientes = _clienteServicio.ObtenerClientes();
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Nombre: {cliente.Nombre}, Email: {cliente.Email}, Teléfono: {cliente.Telefono}, Crédito: {cliente.Credito}");
            }
        }

        public void ModificarCliente()
        {
            Console.WriteLine("Ingrese el ID del cliente a modificar:");
            int id = int.Parse(Console.ReadLine());

            var cliente = _clienteServicio.ObtenerClientePorId(id);
            if (cliente != null)
            {
                Console.WriteLine("Ingrese el nuevo nombre del cliente (o deje en blanco para no cambiar):");
                string nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoNombre))
                {
                    cliente.Nombre = nuevoNombre;
                }

                Console.WriteLine("Ingrese el nuevo crédito del cliente (o deje en blanco para no cambiar):");
                string nuevoCredito = Console.ReadLine();
                if (decimal.TryParse(nuevoCredito, out decimal credito))
                {
                    cliente.Credito = credito;
                }

                _clienteServicio.ModificarCliente(cliente);
                Console.WriteLine("Cliente modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        public void EliminarCliente()
        {
            Console.WriteLine("Ingrese el ID del cliente a eliminar:");
            int id = int.Parse(Console.ReadLine());

            _clienteServicio.EliminarCliente(id);
            Console.WriteLine("Cliente eliminado exitosamente.");
        }

        public void MostrarMenu()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("=== Gestión de Clientes ===");
                Console.WriteLine("1. Crear Cliente");
                Console.WriteLine("2. Consultar Clientes");
                Console.WriteLine("3. Modificar Cliente");
                Console.WriteLine("4. Eliminar Cliente");
                Console.WriteLine("5. Volver al menú principal");
                Console.WriteLine("Seleccione una opción:");

                switch (Console.ReadLine())
                {
                    case "1":
                        CrearCliente();
                        break;
                    case "2":
                        ConsultarClientes();
                        break;
                    case "3":
                        ModificarCliente();
                        break;
                    case "4":
                        EliminarCliente();
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
