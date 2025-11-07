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

        // Métodos simulados para cada opción del menú
        static void GestionarEstudiantes()
        {
            Console.WriteLine("🔧 Gestión de estudiantes (Agregar, Listar, Buscar, Modificar, Eliminar)");
            // Aquí iría la lógica real
        }

        static void GestionarProfesores()
        {
            Console.WriteLine("🔧 Gestión de profesores (Agregar, Listar, Buscar, Modificar, Eliminar)");
        }

        static void GestionarCursos()
        {
            Console.WriteLine("🔧 Gestión de cursos (Agregar, Listar, Asignar Profesor)");
        }

        static void MatricularEstudiante()
        {
            Console.WriteLine("📚 Matricular estudiante en curso");
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
