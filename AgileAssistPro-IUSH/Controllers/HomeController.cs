using AgileAssistPro_IUSH.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace AgileAssistPro_IUSH.Controllers

{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Usuarios()
        {
            return View();
        }

       // [Authorize(Roles = "Admin")]
        public IActionResult Qr()
        {
            return View();
        }
        public IActionResult Asistencia()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
//HOME ES EL INDEX NORMAL PARA TODOS, QUE DICE BIENVENIDO. dEBO CAMBIAR ES EL LAYOUT POR ROL