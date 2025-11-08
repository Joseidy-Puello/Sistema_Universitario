using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Universitario
{
    public class GestorMatriculas
    {
        private readonly List<Matricula> _matriculas = new List<Matricula>();

        // ✓ Matricular estudiante en un curso
        public void MatricularEstudiante(Estudiante estudiante, Curso curso)
        {
            bool yaMatriculado = _matriculas.Any(m =>
                m.Estudiante.NumeroMatricula == estudiante.NumeroMatricula &&
                m.Curso.Codigo == curso.Codigo);

            if (yaMatriculado)
                throw new InvalidOperationException("El estudiante ya está matriculado en este curso.");

            _matriculas.Add(new Matricula
            {
                Estudiante = estudiante,
                Curso = curso,
                FechaMatricula = DateTime.Now
            });
        }

        // ✓ Agregar calificación entre 0 y 10
        public void AgregarCalificacion(string idEstudiante, string codigoCurso, decimal calificacion)
        {
            if (calificacion < 0 || calificacion > 10)
                throw new ArgumentOutOfRangeException(nameof(calificacion), "La calificación debe estar entre 0 y 10.");

            var matricula = _matriculas.FirstOrDefault(m =>
                m.Estudiante.NumeroMatricula == idEstudiante &&
                m.Curso.Codigo == codigoCurso);

            if (matricula == null)
                throw new InvalidOperationException("No se encontró la matrícula para ese estudiante y curso.");

            // Escalar la calificación a base 100 si tu lógica lo requiere
            decimal calificacionEscalada = calificacion * 10;
            matricula.AgregarCalificacion(calificacionEscalada);
        }

        // ✓ Obtener todas las matrículas de un estudiante
        public List<Matricula> ObtenerMatriculasPorEstudiante(string idEstudiante)
        {
            return _matriculas
                .Where(m => m.Estudiante.NumeroMatricula == idEstudiante)
                .ToList();
        }

        // ✓ Obtener todos los estudiantes de un curso
        public List<Estudiante> ObtenerEstudiantesPorCurso(string codigoCurso)
        {
            return _matriculas
                .Where(m => m.Curso.Codigo == codigoCurso)
                .Select(m => m.Estudiante)
                .Distinct()
                .ToList();
        }

        // ✓ Generar reporte de calificaciones por estudiante
        public string GenerarReporteEstudiante(string idEstudiante)
        {
            var matriculas = ObtenerMatriculasPorEstudiante(idEstudiante);

            if (!matriculas.Any())
                return $"No hay matrículas registradas para el estudiante con ID {idEstudiante}.";

            var estudiante = matriculas[0].Estudiante;
            var reporte = $"📋 Reporte académico de {estudiante.Nombre} ({estudiante.NumeroMatricula})\n";

            foreach (var m in matriculas)
            {
                string estado = m.ObtenerEstado();
                decimal promedio = m.ObtenerPromedio();
                reporte += $"- {m.Curso.Nombre} ({m.Curso.Codigo}): Promedio {promedio:0.0} → {estado}\n";
            }

            return reporte;
        }

        public static string ConvertirDatos(object dato)
        {
            switch (dato)
            {
                case int entero:
                    return $"Entero: {entero:N0}";

                case double doble:
                    return $"Decimal doble: {doble:F2}";

                case decimal dec:
                    return $"Decimal: {dec:C2}";

                case string texto:
                    return $"Texto: \"{texto}\"";

                case DateTime fecha:
                    return $"Fecha: {fecha:dddd, dd MMMM yyyy HH:mm}";

                case bool valor:
                    return $"Booleano: {(valor ? "Verdadero" : "Falso")}";

                case null:
                    return "Valor nulo";

                default:
                    return $"Tipo desconocido: {dato.GetType().Name}";
            }
        }

        // Método seguro para convertir string a decimal
        public static bool ParsearCalificacion(string entrada, out decimal calificacion)
        {
            // Usa cultura invariante para evitar errores por coma/punto
            return decimal.TryParse(entrada, NumberStyles.Number, CultureInfo.InvariantCulture, out calificacion);
        }

        // Demostración de boxing y unboxing
        public static void DemostrarBoxingUnboxing()
        {
            // Boxing: convertir tipo valor a object
            int nota = 85;
            object caja = nota; // boxing

            // Unboxing: convertir object a tipo valor
            if (caja is int notaExtraida)
            {
                Console.WriteLine($"✅ Unboxing exitoso: nota = {notaExtraida}");
            }

            // Uso en contexto académico
            object calificacionBoxeada = 7.5m; // boxing de decimal
            if (calificacionBoxeada is decimal calificacionReal)
            {
                string estado = calificacionReal >= 7 ? "Aprobado" : "Reprobado";
                Console.WriteLine($"🎓 Calificación: {calificacionReal} → {estado}");
            }
        }

        //LINQS Y LAMBDA
        // Top 10 estudiantes con mejor promedio general
        public List<Estudiante> ObtenerTop10Estudiantes()
        {
            return _matriculas
                .GroupBy(m => m.Estudiante)
                .Select(g => new
                {
                    Estudiante = g.Key,
                    Promedio = g.Average(m => m.ObtenerPromedio())
                })
                .OrderByDescending(e => e.Promedio)
                .Take(10)
                .Select(e => e.Estudiante)
                .ToList();
        }

        // Estudiantes con promedio menor a 7.0 (base 10)
        public List<Estudiante> ObtenerEstudiantesEnRiesgo()
        {
            return _matriculas
                .GroupBy(m => m.Estudiante)
                .Where(g => g.Average(m => m.ObtenerPromedio()) < 70)
                .Select(g => g.Key)
                .ToList();
        }

        // Cursos más populares por cantidad de estudiantes
        public List<(Curso curso, int cantidad)> ObtenerCursosMasPopulares()
        {
            return _matriculas
                .GroupBy(m => m.Curso)
                .Select(g => (curso: g.Key, cantidad: g.Count()))
                .OrderByDescending(c => c.cantidad)
                .ToList();
        }

        // Promedio general de todos los estudiantes
        public decimal ObtenerPromedioGeneral()
        {
            return _matriculas
                .Where(m => m.ObtenerPromedio() > 0)
                .Average(m => m.ObtenerPromedio());
        }

        // Estadísticas agrupadas por carrera
        public List<(string carrera, int cantidad, decimal promedio)> ObtenerEstadisticasPorCarrera()
        {
            return _matriculas
                .GroupBy(m => m.Estudiante.Carrera)
                .Select(g => (
                    carrera: g.Key,
                    cantidad: g.Select(m => m.Estudiante).Distinct().Count(),
                    promedio: g.Average(m => m.ObtenerPromedio())
                ))
                .ToList();
        }

        // Búsqueda flexible con predicado Func<Estudiante, bool>
        public List<Estudiante> BuscarEstudiantes(Func<Estudiante, bool> criterio)
        {
            return _matriculas
                .Select(m => m.Estudiante)
                .Where(criterio)
                .Distinct()
                .ToList();
        }

        public List<Matricula> ObtenerTodasMatriculas()
        {
            return _matriculas.ToList();
        }

    }
}
