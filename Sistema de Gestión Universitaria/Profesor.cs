using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Universitario
{
    public class Profesor : Persona
    {
        public string Departamento { get; set; }
        public enum TipoContrato
        {
            TiempoCompleto,
            MedioTiempo,
            Contratado
        }

        public decimal SalarioBase { get; set; }
    }
}
