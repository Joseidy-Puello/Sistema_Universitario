using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_Universitario;
using static Sistema_Universitario.AnalizadorReflection;

namespace Sistema_Universitario
{
    public class Curso : IIdentificable
    {
        [Requerido]
        public string Codigo { get; set; }
        [Requerido]
        public string Nombre { get; set; }
        [ValidacionRango(1,10)]
        public int Creditos { get; set; }
        public Profesor Profesor { get; set; }

        public string Identificacion { get; set; }

    }
}
