using System;
using System.Collections.Generic;

namespace AgileAssistPro_IUSH.Models;
//Alejita del futuro, estos modelos se crearon con el fin de interactuar con una tábla que tenemos vínculada en nuestra BD y también con sus campos

public partial class Cursos
{
    public int IdCurso { get; set; }

    public string? Nombre { get; set; }

    public string? Docente { get; set; }
}
