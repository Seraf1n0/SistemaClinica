/*
* Esta clase busca ayudar a manejar la entidad Paciente y reconocer sus atributos para poder almacenar y mostrar la información necesaria.
*/

using Microsoft.AspNetCore.Mvc.RazorPages;

public class Paciente {

    public string cedula { get; set; }
    public string nombre { get; set; }
    public DateTime fechaNacimiento { get; set; }
    public int edad { get; set; }
    public string direccion { get; set; }
}