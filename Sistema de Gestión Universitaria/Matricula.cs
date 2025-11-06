using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_Universitario;

namespace Sistema_Universitario
{
    public class Matricula : IEvaluable 
    {
        public string Estudiante { get; set; }
        public string Curso { get; set; }
        public DateTime FechaMatricula { get; set; }

        private List<decimal> Calificaciones = new List<decimal>();

        // Implementación de los métodos de la interfaz IPromediable
        public void AgregarCalificacion(decimal calificacion)
        {
            if (calificacion >= 0 && calificacion <= 100)
            {
                Calificaciones.Add(calificacion);
            }
        }

        public decimal ObtenerPromedio()
        {
            if (Calificaciones.Count == 0)
                return 0;

            return Calificaciones.Average();
        }

        public bool HaAprobado()
        {
            return ObtenerPromedio() >= 70;
        }
    }

}

