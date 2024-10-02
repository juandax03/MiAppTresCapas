using System;
using MiAppTresCapas.Negocio;
using MiAppTresCapas.Datos;

namespace MiAppTresCapas.Presentacion
{
    public class GestionEmpresas
    {
        private EmpresaServicio _empresaServicio;

        public GestionEmpresas(EmpresaServicio empresaServicio)
        {
            _empresaServicio = empresaServicio;
        }

        public void CrearEmpresa()
        {
            Console.WriteLine("Ingrese el nombre de la empresa:");
            string nombre = Console.ReadLine();

            Empresa empresa = new Empresa { Nombre = nombre };
            _empresaServicio.GuardarEmpresa(empresa);
            Console.WriteLine("Empresa creada exitosamente.");
        }

        public void ConsultarEmpresas()
        {
            var empresas = _empresaServicio.ConsultarEmpresas();
            Console.WriteLine("=== Lista de Empresas ===");
            foreach (var empresa in empresas)
            {
                Console.WriteLine($"ID: {empresa.Id}, Nombre: {empresa.Nombre}");
            }
        }

        public void ModificarEmpresa()
        {
            Console.WriteLine("Ingrese el ID de la empresa a modificar:");
            int id = int.Parse(Console.ReadLine());

            var empresa = _empresaServicio.ObtenerEmpresaPorId(id);
            if (empresa != null)
            {
                Console.WriteLine("Ingrese el nuevo nombre de la empresa:");
                empresa.Nombre = Console.ReadLine();

                _empresaServicio.ModificarEmpresa(empresa);
                Console.WriteLine("Empresa modificada exitosamente.");
            }
            else
            {
                Console.WriteLine("Empresa no encontrada.");
            }
        }

        public void EliminarEmpresa()
        {
            Console.WriteLine("Ingrese el ID de la empresa a eliminar:");
            int id = int.Parse(Console.ReadLine());

            _empresaServicio.BorrarEmpresa(id);
            Console.WriteLine("Empresa eliminada exitosamente.");
        }

        public void MostrarMenu()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("=== Gestión de Empresas ===");
                Console.WriteLine("1. Crear Empresa");
                Console.WriteLine("2. Consultar Empresas");
                Console.WriteLine("3. Modificar Empresa");
                Console.WriteLine("4. Eliminar Empresa");
                Console.WriteLine("5. Volver al menú principal");

                switch (Console.ReadLine())
                {
                    case "1":
                        CrearEmpresa();
                        break;
                    case "2":
                        ConsultarEmpresas();
                        break;
                    case "3":
                        ModificarEmpresa();
                        break;
                    case "4":
                        EliminarEmpresa();
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
