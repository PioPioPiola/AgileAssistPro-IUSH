

    /*using AgileAssistPro_IUSH.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AgileAssistPro_IUSH.Controllers
{public class RevisionUsuario
    {
        private readonly AgileAssistProIushContext _Context;
        public RevisionUsuario (AgileAssistProIushContext context)
        {
            _Context = context;
        }
        public async Task <string> InterfazUser (int Contraseña, string CorreoIngreso)
            //InterfazUser es el método de la tarea anteriormente programada.
        {
            var usuario = await _Context.Usuarios.FirstOrDefaultAsync (u => u.Id == Contraseña && u.Correo == CorreoIngreso);
            if (usuario != null) 
            {
                switch (usuario.Rol)
                {
                    case "Admin":
                        return "Index";
                    case "Estudiante":
                        return "EstudiantesIndex";
                    case "Docente":
                        return "DocentesIndex";
                    default: return "LoginError";
                }
            }
            else
            {
                return "LoginError";
                //Debo diseñar una vista para el error de ingreso
            }
        }
    }
}*/
