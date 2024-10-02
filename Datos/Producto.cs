public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } // required para asegurar que Nombre sea inicializado
    public decimal ValorUnitario { get; set; }

    public Producto(string nombre, decimal valorUnitario)
    {
        Nombre = nombre;
        ValorUnitario = valorUnitario;
    }

    public Producto(string nombre) { 
    Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
    }
}
