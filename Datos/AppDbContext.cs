using Microsoft.EntityFrameworkCore; // Importa la biblioteca necesaria para trabajar con Entity Framework Core.

namespace MiAppTresCapas.Datos
{
    // Esta clase representa el contexto de la base de datos, la cual se utiliza para interactuar con las tablas de la base de datos
    public class AppDbContext : DbContext
    {
        // Constructor de la clase AppDbContext que recibe las opciones de configuración del DbContext y las pasa a la clase base DbContext.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet representa una tabla en la base de datos. Cada propiedad aquí corresponde a una tabla.
        public DbSet<Persona> Personas { get; set; } // Tabla para las personas (base de herencia)
        public DbSet<Vendedor> Vendedores { get; set; } // Tabla para los vendedores (hereda de Persona)
        public DbSet<Cliente> Clientes { get; set; } // Tabla para los clientes (hereda de Persona)
        public DbSet<Empresa> Empresas { get; set; } // Tabla para las empresas
        public DbSet<Factura> Facturas { get; set; } // Tabla para las facturas
        public DbSet<ProductosPorFactura> ProductosPorFacturas { get; set; } // Tabla para los productos por factura
        public DbSet<Producto> Productos { get; set; } // Tabla para los productos

        // Este método se utiliza para configurar la conexión a la base de datos.
        // Si no se recibe la configuración por otro lado, este método garantiza que se use el servidor SQL especificado.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configura la conexión a la base de datos. Usa SQL Server como proveedor y conecta con la base de datos 'MiAppTresCapasDB'.
            optionsBuilder.UseSqlServer(@"Server=.;Database=MiAppTresCapasDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;");
        }

        // Este método se utiliza para configurar las relaciones y mapeos en el modelo, como herencias, relaciones entre entidades, etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Llama al método base para asegurar que cualquier configuración predeterminada también se aplique.
            base.OnModelCreating(modelBuilder);

            // **Herencia por Tabla (TPT):**
            // Configura la herencia de la clase base 'Persona' y las clases derivadas 'Cliente' y 'Vendedor' en diferentes tablas.

            // Configura que la clase 'Persona' se mapee a la tabla "Personas".
            modelBuilder.Entity<Persona>()
                .ToTable("Personas"); // Personas será la tabla base de la herencia.

            // Configura que la clase 'Cliente' se mapee a la tabla "Clientes", separada de 'Personas'.
            modelBuilder.Entity<Cliente>()
                .ToTable("Clientes"); // Tabla específica para Cliente.

            // Configura que la clase 'Vendedor' se mapee a la tabla "Vendedores", separada de 'Personas'.
            modelBuilder.Entity<Vendedor>()
                .ToTable("Vendedores"); // Tabla específica para Vendedor.

            // **Relaciones:**

            // Configuración de la relación entre Cliente y Empresa.
            // Un cliente está relacionado con una empresa. Cada cliente tiene una empresa asociada, representada por 'EmpresaId'.
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Empresa) // Un cliente tiene una empresa.
                .WithMany() // Una empresa puede tener muchos clientes.
                .HasForeignKey(c => c.EmpresaId) // Clave foránea de la tabla Cliente que apunta a la Empresa.
                .OnDelete(DeleteBehavior.Restrict); // Al eliminar una empresa, se restringe la eliminación de clientes para evitar inconsistencia en los datos.

            // Configuración de la relación entre ProductosPorFactura y Factura.
            // Una factura puede tener múltiples productos por factura.
            modelBuilder.Entity<ProductosPorFactura>()
                .HasOne(pf => pf.Factura) // Un producto por factura está asociado a una factura.
                .WithMany(f => f.ProductosPorFactura) // Una factura tiene muchos productos por factura.
                .HasForeignKey(pf => pf.FacturaId) // Clave foránea de la tabla ProductosPorFactura que apunta a la tabla Factura.
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina una factura, se eliminan los productos relacionados.

            // Configuración de la relación entre ProductosPorFactura y Producto.
            // Un producto por factura está relacionado con un producto específico.
            modelBuilder.Entity<ProductosPorFactura>()
                .HasOne(pf => pf.Producto) // Un producto por factura está asociado a un producto.
                .WithMany() // Un producto puede estar asociado con múltiples productos por factura.
                .HasForeignKey(pf => pf.ProductoId) // Clave foránea de la tabla ProductosPorFactura que apunta a la tabla Producto.
                .OnDelete(DeleteBehavior.Restrict); // Restringe la eliminación de productos si están referenciados en productos por factura.

            // Configuración de la relación entre Factura y Persona.
            // Una factura está asociada a una persona (que puede ser un cliente o un vendedor).
            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Persona) // Una factura está asociada a una persona.
                .WithMany() // Una persona puede estar asociada con múltiples facturas.
                .HasForeignKey(f => f.PersonaId) // Clave foránea de la tabla Factura que apunta a la tabla Personas.
                .OnDelete(DeleteBehavior.Restrict); // Restringe la eliminación de personas si tienen facturas asociadas.
        }
    }
}
