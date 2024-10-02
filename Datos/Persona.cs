namespace MiAppTresCapas.Datos
{
public abstract class Persona
{
    public int Id { get; set; }  // Clave primaria
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }


    // Constructor que asegura la inicialización de las propiedades no nulas
    public Persona(string nombre, string email, string telefono)
    {
        Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
    }
}
}