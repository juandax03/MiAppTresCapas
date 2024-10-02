using System.Collections.Generic;
using System.Linq;
using MiAppTresCapas.Datos;

namespace MiAppTresCapas.Negocio
{
    public class ClienteServicio
    {
        private readonly AppDbContext _context;

        public ClienteServicio(AppDbContext context)
        {
            _context = context;
        }

        public List<Cliente> ObtenerClientes()
        {
            return _context.Clientes.ToList();
        }

        public Cliente? ObtenerClientePorId(int id)
        {
            return _context.Clientes.Find(id);
        }

        public void AgregarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void ModificarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void EliminarCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
