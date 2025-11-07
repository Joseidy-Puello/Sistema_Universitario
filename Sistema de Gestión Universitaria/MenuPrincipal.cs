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

                static void RegistrarCalificacion()
                {
                    Console.WriteLine("📝 Registrar calificaciones");
                }

                static void VerReportes()
                {
                     Console.WriteLine("📊 Ver reportes de estudiantes, cursos y estadísticas");
                }

                static void AnalizarConReflection()
                {
                    Console.WriteLine("🔍 Análisis dinámico con Reflection");
                }
            }
        }

    }
}