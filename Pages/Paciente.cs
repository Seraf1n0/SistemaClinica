// Clase para mantener los datos ingresados y almacenarlos

using Microsoft.AspNetCore.Mvc.RazorPages;

public class Paciente {

    public string cedula { get; set; }
    public string nombre { get; set; }
    public DateTime fechaNacimiento { get; set; }
    public int edad { get; set; }
    public string direccion { get; set; }
}