using AgileAssistPro_IUSH.Models;
using Microsoft.EntityFrameworkCore;
namespace AgileAssistPro_IUSH.Data
{
    public class Da_Logica
    {
        private readonly AgileAssistProIushContext _context;

        public Da_Logica(AgileAssistProIushContext context)
        {
            _context = context;
        }

        public async Task<List<Usuarios>> ListaUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuarios> ValidarUsuario(string CorreoIngreso, int Contraseña)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == CorreoIngreso && u.Id == Contraseña);
        }
    }
}
 