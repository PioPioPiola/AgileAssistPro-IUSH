using AgileAssistPro_IUSH.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgileAssistPro_IUSH.Models;

namespace AgileAssistPro_IUSH.Controllers
{
    public class MonitoreoClases : Controller
    {
        private readonly AgileAssistProIushContext _context;

        public MonitoreoClases(AgileAssistProIushContext context)
        {
            _context = context;
        }

        public async Task <IActionResult> MonitoreoAsis()
        {
            return _context.Usuarios != null ?
                View(await _context.Usuarios.ToListAsync()) :
                Problem("Entity set 'AgileAssistProIushContext.Usuarios' is null.");
        }
    }
}
