using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecuriticCargaEstres.Pages
{
    public class FormularioModel : PageModel
    {
        public string Nombre { get; set; }
        public string Id { get; set; }
        public void OnGetLogin(string id, string nombre)
        {
            Nombre = nombre;
            Id = id;
        }
        public void OnGet()
        {

        }

        public ActionResult Onpost()
        {
            return RedirectToPage("Boton");
        }
    }
}