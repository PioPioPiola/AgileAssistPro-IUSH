using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgileAssistPro_IUSH.Models;

public partial class Usuarios
{
    [Key]
    public int Id { get; set; }

    public string[] Rol { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string IdCurso { get; set; } = null!;
    public string Hora { get; set; } = null!;
    //Importante hacer estos cambio en la Base de datos y eliminar la tabla cursos, cambiarla por asistencias.
}
