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