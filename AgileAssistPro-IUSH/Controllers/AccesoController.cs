using Microsoft.AspNetCore.Mvc;
using AgileAssistPro_IUSH.Models;
using AgileAssistPro_IUSH.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace AgileAssistPro_IUSH.Controllers
{
    public class AccesoController : Controller
    {
        private readonly Da_Logica _da_Logica;

        public AccesoController(Da_Logica da_Logica)
        {
            _da_Logica = da_Logica;
        }
        public IActionResult Acceso()
        {
            return View();
            //Aleja, por favor nunca cambies el nombre de la vista. Es el login
        }

        [HttpPost]
        
        public async Task <IActionResult> Acceso(Usuarios _usuarios)
        {
            var LoginUser = await _da_Logica.ValidarUsuario(_usuarios.Correo, _usuarios.Id);
            //Usuario prueba cambiarlo por LoginUser == usuario encontrado. Donde diga usuarioPrueba
            if (LoginUser != null)
            {//Creación cookie de autorización
                  var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, LoginUser.Correo),
                    new Claim("Nombre", LoginUser.Nombre),
            };
                if (!string.IsNullOrEmpty(LoginUser.Rol))
                {
                    claims.Add(new Claim(ClaimTypes.Role, LoginUser.Rol));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                //Lógica para identificar los roles de los ususarios. Debo cambiarla para que sea con respecto a la BD.

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            //Revisa si el usuario ingresado existe, si sí, le muestra la vista de Home, sino, vuelve a la vista dle login
        }
        public async Task <IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Acceso", "Acceso");
        }
    }
}
