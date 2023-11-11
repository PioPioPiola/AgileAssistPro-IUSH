using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgileAssistPro_IUSH.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgileAssistPro_IUSH.Controllers
{
    public class UsuariosCRUD : Controller
    {
        private readonly AgileAssistProIushContext _context;
        
        public UsuariosCRUD (AgileAssistProIushContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> UsuariosIndex()
        {
            return _context.Usuarios != null ?
                View(await _context.Usuarios.ToListAsync()) : Problem("Entity set 'AgileAssistProIushContext.Usuarios' is null.");
        }

        //Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuarioRegistrado = await _context.Usuarios
                //DADo que la variable usuario existe en otro contexto, aquí le sgrego la palabra registrado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioRegistrado == null)
            {
                return NotFound();
            }

            return View(usuarioRegistrado);
        }
        //Opción crear usuarios
        public IActionResult Create ()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rol,Nombre,Correo,IdCurso")] Usuarios usuarioRegistrado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioRegistrado);
                await _context.SaveChangesAsync();
            }
            return View(usuarioRegistrado);
        }

        //Opción Editar Usuarios. GET
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null|| _context.Usuarios == null)
            {
                return NotFound();
            }
            var usuarioRegistrado = await _context.Usuarios.FindAsync(id);
            if(usuarioRegistrado== null)
            {
                return NotFound();
            }
            return View(usuarioRegistrado);
        }
        //Post Editar usuarios
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rol,Nombre,Correo,IdCurso")] Usuarios usuarioRegistrado)
        {
            if (id!=usuarioRegistrado.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioRegistrado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!UsuarioExists(usuarioRegistrado.Id)) //Si el usuario registrado con ese rol no existe, retornar...
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioRegistrado);
        }

        //Empezar con e Get Delete
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }
            var usuarioRegistrado = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioRegistrado == null)
            {
                return NotFound();
            }
            return View(usuarioRegistrado);
        }
        //Post de la opción Delete

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed (string id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'AgileAssistProIushContext.Usuarios' is null.");
            }
            var usuarioRegistrado = await _context.Usuarios.FindAsync(id);
            if (usuarioRegistrado!= null)
            {
                _context.Usuarios.Remove(usuarioRegistrado);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool UsuarioExists (int id)
        {
            return (_context.Usuarios?.Any(e=>e.Id == id)).GetValueOrDefault();
        }

    }
}
