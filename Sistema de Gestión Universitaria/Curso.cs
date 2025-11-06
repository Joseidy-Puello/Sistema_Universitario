using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_Universitario;

namespace Sistema_de_Gestión_Universitaria
{
    internal class Curso
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public Profesor Profesor { get; set; }

    }
}
