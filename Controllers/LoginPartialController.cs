using Microsoft.AspNetCore.Mvc;

namespace AgileAssistPro_IUSH.Controllers
{
    public class LoginPartialController : Controller
    {
        public IActionResult LoginIndex()
        {
            return View();
        }
    }
}
