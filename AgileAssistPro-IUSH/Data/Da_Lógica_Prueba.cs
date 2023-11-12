using AgileAssistPro_IUSH.Models;
namespace AgileAssistPro_IUSH.Data
{
    public class Da_Lógica_Prueba
    {
        public List <Usuarios> ListaUsuariosPrueba()
        {
            return new List<Usuarios>
            {
                new Usuarios{Id = 1000872959, Nombre="Alejandra Bedoya",Correo="Admin@gmail.com", IdCurso="N/A", Hora="N/A", Rol= "Admin"},
                new Usuarios{Id = 1000872958, Nombre="Juan Bedoya",Correo="Docente@gmail.com", IdCurso="Matemáticas",Hora="7:00", Rol= "Docente"},
                new Usuarios{Id = 1000872957, Nombre="Juan Gil",Correo="Estudiante@gmail.com", IdCurso="Matemáticas", Hora="7:00", Rol="Estudiante"},
                new Usuarios{Id = 202320033, Nombre="Prueba",Correo="Prueba@gmail.com", IdCurso="Inglés",Hora="8:00", Rol= "Estudiante"},
                //Validar como sería los tipos de usuarios
            };
        }
        public Usuarios ValidarUsuarioPrueba(string _CorreoIngreso, int _Contraseña)
        {
            return ListaUsuariosPrueba().Where(item => item.Correo == _CorreoIngreso && item.Id == _Contraseña).FirstOrDefault();

        }
    }
}
 