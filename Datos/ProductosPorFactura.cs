namespace MiAppTresCapas.Datos
{
public class ProductosPorFactura
{
    public int Id { get; set; }  // Clave primaria
    public int Cantidad { get; set; }
    public decimal Subtotal { get; set; }

    // Relación con Factura
    public int FacturaId { get; set; }  // Clave foránea
    public Factura Factura { get; set; }

    // Relación con Producto
    public int ProductoId { get; set; }  // Clave foránea
    public Producto Producto { get; set; }

    // Constructor vacío requerido por Entity Framework
    public ProductosPorFactura() { }
    
    // Constructor que asegura la inicialización de Factura
    public ProductosPorFactura(Factura factura, Producto producto)
    {
        Factura = factura ?? throw new ArgumentNullException(nameof(factura));
        Producto = producto ?? throw new ArgumentNullException(nameof(producto));
    }
}
}