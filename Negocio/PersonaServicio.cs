using System.Collections.Generic;
using System.Linq;
using MiAppTresCapas.Datos;

namespace MiAppTresCapas.Negocio
{
    public class PersonaServicio
    {
        private readonly AppDbContext _context;

        public PersonaServicio(AppDbContext context)
        {
            _context = context;
        }

        public List<Persona> ConsultarPersonas()
        {
            return _context.Personas.ToList();
        }

        public Persona? ObtenerPersonaPorId(int id)
        {
            return _context.Personas.Find(id);
        }

        public void IngresarPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
        }

        public void ModificarPersona(Persona persona)
        {
            _context.Personas.Update(persona);
            _context.SaveChanges();
        }

        public void BorrarPersona(int id)
        {
            var persona = _context.Personas.Find(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                _context.SaveChanges();
            }
        }

        public bool VerificarPersona(int id)
        {
            return _context.Personas.Any(p => p.Id == id);
        }
    }
}
