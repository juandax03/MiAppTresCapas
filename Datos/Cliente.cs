namespace MiAppTresCapas.Datos
{
public class Cliente : Persona
{
    public decimal Credito { get; set; }

    // Relación de agregación con Empresa
    public int? EmpresaId { get; set; }
    public Empresa? Empresa { get; set; }

        // Constructor que acepta todos los parámetros incluidos Empresa
        public Cliente(string nombre, string email, string telefono, decimal credito, Empresa empresa)
            : base(nombre, email, telefono)
        {
            Credito = credito;
            Empresa = empresa ?? throw new ArgumentNullException(nameof(empresa)); // Asegúrate de que la empresa no sea nula
        }

        // Constructor sin empresa para cuando no se asocia una empresa al cliente
        public Cliente(string nombre, string email, string telefono, decimal credito)
            : base(nombre, email, telefono)
        {
            Credito = credito;
        }
}
}
