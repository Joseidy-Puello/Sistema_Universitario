using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_Universitario.AnalizadorReflection;

namespace Sistema_Universitario
{
    public class Profesor : Persona
    {
        [Requerido]
        public string Departamento { get; set; }
        public enum TipoContrato
        {
            TiempoCompleto,
            MedioTiempo,
            Contratado
        }

        [ValidacionRango(500, 10000)]
        public decimal SalarioBase { get; set; }
        public string CodigoEmpleado { get; set; }
    }
}
