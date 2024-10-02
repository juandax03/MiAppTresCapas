using System.Collections.Generic;
using System.Linq;
using MiAppTresCapas.Datos;

namespace MiAppTresCapas.Negocio
{
    public class EmpresaServicio
    {
        private readonly AppDbContext _context;

        public EmpresaServicio(AppDbContext context)
        {
            _context = context;
        }

        public List<Empresa> ConsultarEmpresas()
        {
            return _context.Empresas.ToList();
        }

        public Empresa? ObtenerEmpresaPorId(int id)
        {
            return _context.Empresas.Find(id);
        }

        public void GuardarEmpresa(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            _context.SaveChanges();
        }

        public void ModificarEmpresa(Empresa empresa)
        {
            _context.Empresas.Update(empresa);
            _context.SaveChanges();
        }

        public void BorrarEmpresa(int id)
        {
            var empresa = _context.Empresas.Find(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
                _context.SaveChanges();
            }
        }
    }
}
