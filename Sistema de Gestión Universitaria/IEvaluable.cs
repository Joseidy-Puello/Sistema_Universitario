using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sistema_Universitario
{
    public interface IEvaluable
    {
        void AgregarCalificacion(decimal calificacion);
        decimal ObtenerPromedio();
        bool HaAprobado();
    }
}
