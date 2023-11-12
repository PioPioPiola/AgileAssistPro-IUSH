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
        public IActionResult Acceso()
        {
            return View();
            //Aleja, por favor nunca cambies el nombre de la vista. Es el login
        }

        [HttpPost]
        
        public async Task <IActionResult> Acceso(Usuarios _usuarios)
        {
            Da_Lógica_Prueba _da_usuario_prueba = new Da_Lógica_Prueba();
            //Hacer esto mismo, pero con la BD.

            var usuarioPrueba = _da_usuario_prueba.ValidarUsuarioPrueba(_usuarios.Correo, _usuarios.Id);
            //Usuario prueba cambiarlo por LoginUser == usuario encontrado
            if (usuarioPrueba != null)
            {
                //Creación cookie de autorización
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuarioPrueba.Nombre),
                    new Claim("Correo", usuarioPrueba.Correo)
                };

                foreach(string rol in usuarioPrueba.Rol)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
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
