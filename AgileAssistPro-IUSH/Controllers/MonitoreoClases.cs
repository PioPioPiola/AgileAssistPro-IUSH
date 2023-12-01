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

        public async Task<IActionResult> MonitoreoAsis()
        {
            return _context.Usuarios != null ?
                View(await _context.Usuarios.ToListAsync()) :
                Problem("Entity set 'AgileAssistProIushContext.Usuarios' is null.");
        }

        const int clasesTotal = 25;
        const float faltasPermitidas = clasesTotal * 0.20f;

        [HttpPost]
        public async Task<IActionResult> MarcarAsistencia(int EstudianteId)
        {
            var usuarioEstudiante = await _context.Usuarios.FindAsync(EstudianteId);
            if (usuarioEstudiante != null)
            {
                if ((usuarioEstudiante.Asistencia< clasesTotal)&&(usuarioEstudiante.Inasistencia < faltasPermitidas))
                {
                    usuarioEstudiante.Asistencia++;
                    _context.Update(usuarioEstudiante);
                    await _context.SaveChangesAsync();
                    TempData["MensajeExito"] = "¡Registro de asistencia exitoso!";
                    return RedirectToAction("MonitoreoAsis");

                }
                else if (usuarioEstudiante.Asistencia==clasesTotal)
                {
                    TempData["Mensaje"] = "El curso ha finalizado. No existen clases para marcar asisencia.";
                    return RedirectToAction("MonitoreoAsis");
                }
                else
                {
                    TempData["Mensaje"] = "No es posible marcar asistencia. Curso cancelado";
                    return RedirectToAction("MonitoreoAsis");

                }
            }
            return NotFound();
        }
        //Inasistencia
        [HttpPost]
        public async Task<IActionResult> ConteoFaltas(int EstudianteId)
        {

            var usuarioEstudiante = await _context.Usuarios.FindAsync(EstudianteId);
            if (usuarioEstudiante != null)
            {
                if (usuarioEstudiante.Inasistencia < faltasPermitidas)
                {
                    usuarioEstudiante.Inasistencia++;
                    _context.Update(usuarioEstudiante);
                    await _context.SaveChangesAsync();
                    TempData["Mensaje"] = $"¡Ojo! el estudiante lleva {usuarioEstudiante.Inasistencia} faltas. Le quedan {(int)Math.Floor(faltasPermitidas-usuarioEstudiante.Inasistencia)} vidas";
                    return RedirectToAction("MonitoreoAsis");
                }
                else
                {
                    TempData["Mensaje"] = "No es posible marcar inasistencia. Curso cancelado";
                    return RedirectToAction("MonitoreoAsis");
                }
            }
            return NotFound();
        }

    }


}


