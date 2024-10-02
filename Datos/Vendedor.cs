namespace MiAppTresCapas.Datos
{
public class Vendedor : Persona
{
    public string Carnet { get; set; }
    public string Direccion { get; set; }

     // Constructor de Vendedor que llama al constructor base de Persona
    public Vendedor(string nombre, string email, string telefono, string carnet, string direccion)
        : base(nombre, email, telefono)  // Llamada al constructor de la clase base
    {
        Carnet = carnet ?? throw new ArgumentNullException(nameof(carnet));
        Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
    }
}
}