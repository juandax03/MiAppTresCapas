namespace MiAppTresCapas.Datos
{
public class Factura
{
    // Relación de composición con ProductosPorFactura
    public List<ProductosPorFactura> ProductosPorFactura { get; set; }
     public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }

    // Propiedad de Navegación hacia Persona
    public int PersonaId { get; set; }
    public Persona? Persona { get; set; }  // Propiedad de Navegación
    // Constructor sin parámetros
    public Factura()
    {
        ProductosPorFactura = new List<ProductosPorFactura>();  // Siempre inicializamos esta lista
    }
}
}