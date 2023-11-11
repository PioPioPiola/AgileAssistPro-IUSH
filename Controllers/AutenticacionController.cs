using System.Threading.Tasks;
using AgileAssistPro_IUSH.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgileAssistPro_IUSH.Controllers
{
    public class LoginController : Controller
    {
        private readonly RevisionUsuario _revisionUsuario;

        public LoginController(RevisionUsuario revisionUsuario)
        {
            _revisionUsuario = revisionUsuario;
        }
        [HttpGet]


        [HttpPost]
        public async Task<IActionResult> Login (int Contraseña, string CorreoElectronico)
        //Login es el método que realizará la autenticación. 
        {
            string vista = await _revisionUsuario.InterfazUser(Contraseña,CorreoElectronico);
       switch (vista)
            {
                case "Index":
                    return View("Index");
                case "EstudiantesIndex":
                    return View("EstudiantesIndex");
                case "DocentesIndex":
                    return View("DocentesIndex");
                case "LoginError":
                    ViewBag.Error = "Credenciales inválidas. Por favor intente de nuevo.";
                    return View();
                default:
                    ViewBag.Error = "Credenciales inválidas. Por favor intente de nuevo.";
                    return View(); ;
            }

        }

    }
}
