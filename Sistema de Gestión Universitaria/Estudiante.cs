using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_Universitario.AnalizadorReflection;

namespace Sistema_Universitario
{
    public class Estudiante : Persona
    {
        [Requerido]
        public string Carrera { get; set; }

        [Formato(@"^[A-Z]{3}-\d{5}$")] // Ejemplo: UCE-12345
        public string NumeroMatricula { get; set; }

    }
}
