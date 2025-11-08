using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Universitario
{
    public class MenuPrincipal
    {
        static GestorMatriculas gestor = new GestorMatriculas();

        static void Main()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== Sistema Universitario ===");
                Console.ResetColor();
                Console.WriteLine("1. Gestionar Estudiantes");
                Console.WriteLine("2. Gestionar Profesores");
                Console.WriteLine("3. Gestionar Cursos");
                Console.WriteLine("4. Matricular Estudiante en Curso");
                Console.WriteLine("5. Registrar Calificaciones");
                Console.WriteLine("6. Ver Reportes");
                Console.WriteLine("7. Análisis con Reflection");
                Console.WriteLine("8. Salir");
                Console.WriteLine("9. Generar datos de prueba");
                Console.WriteLine("10. Demostrar funcionalidades");

                Console.Write("\nSeleccione una opción: ");

                string entrada = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (entrada)
                    {
                        case "1":
                            GestionarEstudiantes();
                            break;
                        case "2":
                            GestionarProfesores();
                            break;
                        case "3":
                            GestionarCursos();
                            break;
                        case "4":
                            MatricularEstudiante();
                            break;
                        case "5":
                            RegistrarCalificacion();
                            break;
                        case "6":
                            VerReportes();
                            break;
                        case "7":
                            AnalizarConReflection();
                            break;
                        case "8":
                            salir = true;
                            break;
                        case "9":
                            GenerarDatosPrueba();
                            break;
                        case "10":
                            DemostrarFuncionalidades();
                            break;

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Gracias por usar el sistema. ¡Hasta pronto!");
                            Console.ResetColor();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("❌ Opción inválida. Intente nuevamente.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"⚠️ Error: {ex.Message}");
                    Console.ResetColor();
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }


        static List<Estudiante> estudiantes = new List<Estudiante>();

        // Métodos simulados para cada opción del menú
        static void GestionarEstudiantes()
        {
            Console.Clear();
            Console.WriteLine("=== Gestión de Estudiantes ===");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Buscar");
            Console.WriteLine("4. Modificar");
            Console.WriteLine("5. Eliminar");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarEstudiante();
                    break;
                case "2":
                    ListarEstudiantes();
                    break;
                case "3":
                    BuscarEstudiante();
                    break;
                case "4":
                    ModificarEstudiante();
                    break;
                case "5":
                    EliminarEstudiante();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción inválida.");
                    Console.ResetColor();
                    break;
            }
        }

        static void AgregarEstudiante()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Carrera: ");
            string carrera = Console.ReadLine();
            Console.Write("Número de Matrícula (ej. UCE-12345): ");
            string matricula = Console.ReadLine();

            var nuevo = new Estudiante
            {
                Nombre = nombre,
                Carrera = carrera,
                NumeroMatricula = matricula
            };

            estudiantes.Add(nuevo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Estudiante agregado correctamente.");
            Console.ResetColor();
        }

        static void ListarEstudiantes()
        {
            Console.WriteLine("📋 Lista de estudiantes:");
            foreach (var e in estudiantes)
            {
                Console.WriteLine($"- {e.Nombre} ({e.NumeroMatricula}) - {e.Carrera}");
            }
        }

        static void BuscarEstudiante()
        {
            Console.Write("Ingrese número de matrícula: ");
            string id = Console.ReadLine();
            var estudiante = estudiantes.FirstOrDefault(e => e.NumeroMatricula == id);

            if (estudiante != null)
            {
                Console.WriteLine($"🔍 Encontrado: {estudiante.Nombre} - {estudiante.Carrera}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Estudiante no encontrado.");
                Console.ResetColor();
            }
        }

        static void ModificarEstudiante()
        {
            Console.Write("Ingrese número de matrícula: ");
            string id = Console.ReadLine();
            var estudiante = estudiantes.FirstOrDefault(e => e.NumeroMatricula == id);

            if (estudiante != null)
            {
                Console.Write("Nuevo nombre: ");
                estudiante.Nombre = Console.ReadLine();
                Console.Write("Nueva carrera: ");
                estudiante.Carrera = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Estudiante modificado.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Estudiante no encontrado.");
                Console.ResetColor();
            }
        }

        static void EliminarEstudiante()
        {
            Console.Write("Ingrese número de matrícula: ");
            string id = Console.ReadLine();
            var estudiante = estudiantes.FirstOrDefault(e => e.NumeroMatricula == id);

            if (estudiante != null)
            {
                estudiantes.Remove(estudiante);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Estudiante eliminado.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Estudiante no encontrado.");
                Console.ResetColor();
            }
        }

        static List<Profesor> profesores = new List<Profesor>();
        static void GestionarProfesores()
        {
            Console.Clear();
            Console.WriteLine("=== Gestión de Profesores ===");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Buscar");
            Console.WriteLine("4. Modificar");
            Console.WriteLine("5. Eliminar");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarProfesor();
                    break;
                case "2":
                    ListarProfesores();
                    break;
                case "3":
                    BuscarProfesor();
                    break;
                case "4":
                    ModificarProfesor();
                    break;
                case "5":
                    EliminarProfesor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción inválida.");
                    Console.ResetColor();

                    break;
            }
        }

        static void AgregarProfesor()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Departamento: ");
            string departamento = Console.ReadLine();
            Console.Write("Código de Empleado: ");
            string codigo = Console.ReadLine();

            var nuevo = new Profesor
            {
                Nombre = nombre,
                Departamento = departamento,
                CodigoEmpleado = codigo
            };

            profesores.Add(nuevo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Profesor agregado correctamente.");
            Console.ResetColor();
        }

        static void ListarProfesores()
        {
            Console.WriteLine("📋 Lista de profesores:");
            foreach (var p in profesores)
            {
                Console.WriteLine($"- {p.Nombre} ({p.CodigoEmpleado}) - {p.Departamento}");
            }
        }

        static void BuscarProfesor()
        {
            Console.Write("Ingrese código de empleado: ");
            string codigo = Console.ReadLine();
            var profesor = profesores.FirstOrDefault(p => p.CodigoEmpleado == codigo);

            if (profesor != null)
            {
                Console.WriteLine($"🔍 Encontrado: {profesor.Nombre} - {profesor.Departamento}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Profesor no encontrado.");
                Console.ResetColor();
            }
        }

        static void ModificarProfesor()
        {
            Console.Write("Ingrese código de empleado: ");
            string codigo = Console.ReadLine();
            var profesor = profesores.FirstOrDefault(p => p.CodigoEmpleado == codigo);

            if (profesor != null)
            {
                Console.Write("Nuevo nombre: ");
                profesor.Nombre = Console.ReadLine();
                Console.Write("Nuevo departamento: ");
                profesor.Departamento = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Profesor modificado.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Profesor no encontrado.");
                Console.ResetColor();
            }
        }

        static void EliminarProfesor()
        {
            Console.Write("Ingrese código de empleado: ");
            string codigo = Console.ReadLine();
            var profesor = profesores.FirstOrDefault(p => p.CodigoEmpleado == codigo);

            if (profesor != null)
            {
                profesores.Remove(profesor);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Profesor eliminado.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Profesor no encontrado.");
                Console.ResetColor();
            }
        }

        static List<Curso> cursos = new List<Curso>();
        static void GestionarCursos()
        {
            Console.Clear();
            Console.WriteLine("=== Gestión de Cursos ===");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Asignar Profesor");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarCurso();
                    break;
                case "2":
                    ListarCursos();
                    break;
                case "3":
                    AsignarProfesorACurso();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción inválida.");
                    Console.ResetColor();
                    break;
            }
        }

        static void AgregarCurso()
        {
            Console.Write("Nombre del curso: ");
            string nombre = Console.ReadLine();
            Console.Write("Código del curso: ");
            string codigo = Console.ReadLine();
            Console.Write("Créditos: ");
            if (!int.TryParse(Console.ReadLine(), out int creditos))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Créditos inválidos.");
                Console.ResetColor();
                return;
            }

            var nuevo = new Curso
            {
                Nombre = nombre,
                Codigo = codigo,
                Creditos = creditos
            };

            cursos.Add(nuevo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Curso agregado correctamente.");
            Console.ResetColor();
        }

        static void ListarCursos()
        {
            Console.WriteLine("📚 Lista de cursos:");
            foreach (var c in cursos)
            {
                string profesor = c.Profesor != null ? c.Profesor.Nombre : "Sin asignar";
                Console.WriteLine($"- {c.Nombre} ({c.Codigo}) - Créditos: {c.Creditos} - Profesor: {profesor}");
            }
        }

        static void AsignarProfesorACurso()
        {
            Console.Write("Código del curso: ");
            string codigo = Console.ReadLine();
            var curso = cursos.FirstOrDefault(c => c.Codigo == codigo);

            if (curso == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Curso no encontrado.");
                Console.ResetColor();
                return;
            }

            Console.Write("Código del profesor: ");
            string codProf = Console.ReadLine();
            var profesor = profesores.FirstOrDefault(p => p.CodigoEmpleado == codProf);

            if (profesor == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Profesor no encontrado.");
                Console.ResetColor();
                return;
            }

            curso.Profesor = profesor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✅ Profesor {profesor.Nombre} asignado al curso {curso.Nombre}.");
            Console.ResetColor();
        }

        static void MatricularEstudiante()
        {
            {
                Console.Write("Número de matrícula del estudiante: ");
                string idEstudiante = Console.ReadLine();
                var estudiante = estudiantes.FirstOrDefault(e => e.NumeroMatricula == idEstudiante);

                if (estudiante == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Estudiante no encontrado.");
                    Console.ResetColor();
                    return;
                }

                Console.Write("Código del curso: ");
                string codigoCurso = Console.ReadLine();
                var curso = cursos.FirstOrDefault(c => c.Codigo == codigoCurso);

                if (curso == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Curso no encontrado.");
                    Console.ResetColor();
                    return;
                }

                try
                {
                    gestor.MatricularEstudiante(estudiante, curso);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("✅ Matrícula realizada correctamente.");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"❌ Error: {ex.Message}");
                }
                finally
                {
                    Console.ResetColor();

                }



            }
        }

        static void RegistrarCalificacion()
        {
            Console.Write("Número de matrícula del estudiante: ");
            string idEstudiante = Console.ReadLine();

            Console.Write("Código del curso: ");
            string codigoCurso = Console.ReadLine();

            Console.Write("Calificación (0 a 10): ");
            string entrada = Console.ReadLine();

            if (!GestorMatriculas.ParsearCalificacion(entrada, out decimal calificacion))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Calificación inválida.");
                Console.ResetColor();
                return;
            }

            try
            {
                gestor.AgregarCalificacion(idEstudiante, codigoCurso, calificacion);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Calificación registrada correctamente.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
            }
        }

        static void VerReportes()
        {
            Console.Clear();
            Console.WriteLine("=== Reportes Académicos ===");
            Console.WriteLine("1. Reporte por estudiante");
            Console.WriteLine("2. Cursos más populares");
            Console.WriteLine("3. Estadísticas por carrera");
            Console.WriteLine("4. Top 10 estudiantes");
            Console.WriteLine("5. Estudiantes en riesgo");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Número de matrícula: ");
                    string id = Console.ReadLine();
                    string reporte = gestor.GenerarReporteEstudiante(id);
                    Console.WriteLine(reporte);
                    break;

                case "2":
                    var populares = gestor.ObtenerCursosMasPopulares();
                    Console.WriteLine("📚 Cursos más populares:");
                    foreach (var c in populares)
                        Console.WriteLine($"- {c.curso.Nombre} ({c.curso.Codigo}) → {c.cantidad} estudiantes");
                    break;

                case "3":
                    var estadisticas = gestor.ObtenerEstadisticasPorCarrera();
                    Console.WriteLine("📊 Estadísticas por carrera:");
                    foreach (var e in estadisticas)
                        Console.WriteLine($"- {e.carrera}: {e.cantidad} estudiantes, promedio {e.promedio:0.0}");
                    break;

                case "4":
                    var top = gestor.ObtenerTop10Estudiantes();
                    Console.WriteLine("🏅 Top 10 estudiantes:");
                    foreach (var est in top)
                        Console.WriteLine($"- {est.Nombre} ({est.NumeroMatricula})");
                    break;

                case "5":
                    var riesgo = gestor.ObtenerEstudiantesEnRiesgo();
                    Console.WriteLine("⚠️ Estudiantes en riesgo:");
                    foreach (var est in riesgo)
                        Console.WriteLine($"- {est.Nombre} ({est.NumeroMatricula})");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción inválida.");
                    Console.ResetColor();
                    break;
            }
        }

        static void AnalizarConReflection()
        {
            Console.Clear();
            Console.WriteLine("=== Análisis con Reflection ===");
            Console.WriteLine("1. Mostrar propiedades de Estudiante");
            Console.WriteLine("2. Mostrar métodos de Profesor");
            Console.WriteLine("3. Mostrar propiedades de Curso");
            Console.WriteLine("4. Crear instancia dinámica de Curso");
            Console.WriteLine("5. Invocar método en instancia");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AnalizadorReflection.MostrarPropiedades(typeof(Estudiante));
                    break;

                case "2":
                    AnalizadorReflection.MostrarMetodos(typeof(Profesor));
                    break;

                case "3":
                    AnalizadorReflection.MostrarPropiedades(typeof(Curso));
                    break;

                case "4":
                    var instancia = AnalizadorReflection.CrearInstanciaDinamica(typeof(Curso));
                    if (instancia is Curso curso)
                    {
                        curso.Codigo = "REF101";
                        curso.Nombre = "Introducción a Reflection";
                        curso.Creditos = 3;
                        Console.WriteLine($"✅ Curso creado: {curso.Nombre} ({curso.Codigo})");
                    }
                    break;

                case "5":
                    var estudiante = new Estudiante { Nombre = "Joseidy", NumeroMatricula = "UCE-99999", Carrera = "Informática" };
                    var metodo = "ToString"; // Puedes cambiarlo por otro método público
                    var resultado = AnalizadorReflection.InvocarMetodo(estudiante, metodo);
                    Console.WriteLine($"🚀 Resultado de invocación: {resultado}");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción inválida.");
                    Console.ResetColor();
                    break;
            }
        }

        static void GenerarDatosPrueba()
        {
            Console.WriteLine("🔧 Generando datos de prueba...");

            // 1. Estudiantes
            string[] carreras = { "Informática", "Medicina", "Derecho", "Ingeniería", "Psicología" };
            for (int i = 1; i <= 15; i++)
            {
                estudiantes.Add(new Estudiante
                {
                    Nombre = $"Estudiante {i}",
                    NumeroMatricula = $"UCE-{10000 + i}",
                    Carrera = carreras[i % carreras.Length]
                });
            }

            // 2. Profesores
            string[] departamentos = { "Ciencias", "Salud", "Humanidades", "Tecnología", "Administración" };
            for (int i = 1; i <= 5; i++)
            {
                profesores.Add(new Profesor
                {
                    Nombre = $"Profesor {i}",
                    Departamento = departamentos[i - 1],
                    CodigoEmpleado = $"DOC-{2000 + i}"
                });
            }

            // 3. Cursos
            for (int i = 1; i <= 10; i++)
            {
                cursos.Add(new Curso
                {
                    Nombre = $"Curso {i}",
                    Codigo = $"CUR-{300 + i}",
                    Creditos = (i % 4) + 2,
                    Profesor = profesores[i % profesores.Count]
                });
            }

            // 4. Matrículas
            var rand = new Random();
            int totalMatriculas = 0;

            while (totalMatriculas < 30)
            {
                var estudiante = estudiantes[rand.Next(estudiantes.Count)];
                var curso = cursos[rand.Next(cursos.Count)];

                try
                {
                    gestor.MatricularEstudiante(estudiante, curso);
                    totalMatriculas++;
                }
                catch
                {
                    // Ya matriculado, ignorar
                }
            }

            // 5. Calificaciones (3-4 por matrícula, escaladas a base 100)
            foreach (var m in gestor.ObtenerTodasMatriculas())
            {
                int cantidadNotas = rand.Next(3, 5);
                for (int i = 0; i < cantidadNotas; i++)
                {
                    decimal nota10 = (decimal)(rand.NextDouble() * 4 + 6); // entre 6 y 10
                    gestor.AgregarCalificacion(m.Estudiante.NumeroMatricula, m.Curso.Codigo, nota10);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Datos de prueba generados correctamente.");
            Console.ResetColor();
        }


        static void DemostrarFuncionalidades()
        {
            Console.WriteLine("\n=== 🔍 Demostración de Funcionalidades ===");

            // 1. Consultas LINQ
            Console.WriteLine("\n📊 Promedio general:");
            Console.WriteLine($"→ {gestor.ObtenerPromedioGeneral():0.00}");

            Console.WriteLine("\n🏅 Top 10 estudiantes:");
            foreach (var e in gestor.ObtenerTop10Estudiantes())
                Console.WriteLine($"- {e.Nombre} ({e.NumeroMatricula})");

            Console.WriteLine("\n⚠️ Estudiantes en riesgo:");
            foreach (var e in gestor.ObtenerEstudiantesEnRiesgo())
                Console.WriteLine($"- {e.Nombre} ({e.NumeroMatricula})");

            Console.WriteLine("\n📚 Cursos más populares:");
            foreach (var c in gestor.ObtenerCursosMasPopulares())
                Console.WriteLine($"- {c.curso.Nombre} → {c.cantidad} estudiantes");

            Console.WriteLine("\n📈 Estadísticas por carrera:");
            foreach (var e in gestor.ObtenerEstadisticasPorCarrera())
                Console.WriteLine($"- {e.carrera}: {e.cantidad} estudiantes, promedio {e.promedio:0.0}");

            // 2. Reflection
            Console.WriteLine("\n🔬 Análisis con Reflection:");
            AnalizadorReflection.MostrarPropiedades(typeof(Estudiante));
            AnalizadorReflection.MostrarMetodos(typeof(Curso));

            // 3. Validación con atributos personalizados
            Console.WriteLine("\n✅ Validación con atributos personalizados:");
            var estudianteInvalido = new Estudiante { Nombre = "", NumeroMatricula = "123", Carrera = null };
            var errores = Validador.Validar(estudianteInvalido);
            foreach (var error in errores)
                Console.WriteLine($"❌ {error}");

            // 4. Boxing / Unboxing
            Console.WriteLine("\n📦 Ejemplo de boxing/unboxing:");
            GestorMatriculas.DemostrarBoxingUnboxing();

            // 5. Conversiones
            Console.WriteLine("\n🔄 Ejemplos de conversión:");
            Console.WriteLine(GestorMatriculas.ConvertirDatos(123));
            Console.WriteLine(GestorMatriculas.ConvertirDatos(45.67));
            Console.WriteLine(GestorMatriculas.ConvertirDatos("Texto de prueba"));
            Console.WriteLine(GestorMatriculas.ConvertirDatos(DateTime.Now));
        }
    }

}