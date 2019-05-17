using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecuriticCargaEstres.Pages
{


    public class BotonModel : PageModel
    {
        public void OnGet()
        {

        }

        //Ejecuta la terminal con el comando ab y el url ingresado por el usuario
        public ActionResult OnPost()
        {
            string url = Request.Form["URL"];
            return new JsonResult(new { salida = RunCommand("ab", "-n 100 -c 10 http://www." + url + "/") });

            /*string salida = RunCommand("ab", "-n 100 -c 10 " + url);
            string parametros = @"\[([^\[\]]+)\]";
            int ctr = 0;
            foreach (Match m in Regex.Matches(salida, parametros))*/

            //return new JsonResult( ++ctr, m.Groups[1].Value);
            // ("{0}: {1}", ++ctr, m.Groups[1].Value);
        }

        //Metodo para utilizar la terminal de comandos
        string RunCommand(string command, string args)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (string.IsNullOrEmpty(error)) { return output; }
            else { return error; }
        }
    }
}
