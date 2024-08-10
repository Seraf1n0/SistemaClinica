// Pages/Pacientes/ShowAll.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

public class ShowAllModel : PageModel{
    public List<Paciente> Pacientes { get; set; }

    public void OnGet() {
        var fileName = Path.Combine(Directory.GetCurrentDirectory(), "pacientes.json");
        if (System.IO.File.Exists(fileName)) {
            var jsonData = System.IO.File.ReadAllText(fileName);
            Pacientes = JsonSerializer.Deserialize<List<Paciente>>(jsonData);
        }
        else {
            Pacientes = new List<Paciente>();
        }
    }
}