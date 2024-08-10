using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WEBAPP_Clinica_Registro.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Paciente Paciente { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost() {
            // Validaciones generales
            if (Paciente.cedula.Length != 10) { //Suponiendo que deba de ser de esa longitud 
                ModelState.AddModelError("Paciente.cedula", "La cédula debe tener 10 números.");
            }

            if (Paciente.nombre.Length > 100) {
                ModelState.AddModelError("Paciente.nombre", "El nombre no puede tener más de 100 caracteres.");
            }

            if (Paciente.fechaNacimiento > DateTime.Today) {
                ModelState.AddModelError("Paciente.fechaNacimiento", "La fecha de nacimiento debe ser anterior a hoy."); // Evita que se ponga una fecha de nacimiento no existente a dia de hoy
            }
            
            if (Paciente.edad < 0 || Paciente.edad > 120) {
                ModelState.AddModelError("Paciente.edad", "La edad debe estar entre 0 y 120 años."); // Es un estandar, puede cambiar
            }
            
            if (!ModelState.IsValid) {
                return Page();
            }
            // Guarda el paciente en un archivo JSON
            var pacientes = new List<Paciente>();
            var fileName = Path.Combine(Directory.GetCurrentDirectory(), "pacientes.json");
            // Se verifica si el archivo ya existe (en caso de tener datos almacenados ya)
            if (System.IO.File.Exists(fileName)) {
                var jsonData = System.IO.File.ReadAllText(fileName);
                pacientes = JsonSerializer.Deserialize<List<Paciente>>(jsonData);
            }

            pacientes.Add(Paciente);
            var jsonString = JsonSerializer.Serialize(pacientes);
            System.IO.File.WriteAllText(fileName, jsonString);

            return RedirectToPage("ShowAll");
        }
    }
}