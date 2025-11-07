using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Sistema_Universitario.AnalizadorReflection;

namespace Sistema_Universitario
{
    public class Validador
    {
        // Método principal que valida una instancia usando atributos personalizados
        public static List<string> Validar(object instancia)
        {
            var errores = new List<string>(); // Lista para acumular errores encontrados
            var tipo = instancia.GetType();   // Obtiene el tipo de la instancia (ej. Estudiante, Curso)

            // Recorre todas las propiedades públicas del tipo
            foreach (var propiedad in tipo.GetProperties())
            {
                var valor = propiedad.GetValue(instancia); // Obtiene el valor actual de la propiedad

                // 🔹 Validación de [Requerido]
                if (propiedad.IsDefined(typeof(RequeridoAttribute), true))
                {
                    // Verifica si el valor es nulo o vacío (en caso de string)
                    if (valor == null || (valor is string texto && string.IsNullOrWhiteSpace(texto)))
                    {
                        errores.Add($"La propiedad '{propiedad.Name}' es requerida.");
                    }
                }

                // 🔹 Validación de [ValidacionRango]
                var rangoAttr = propiedad.GetCustomAttribute<ValidacionRangoAttribute>();
                if (rangoAttr != null && valor != null)
                {
                    // Intenta convertir el valor a decimal para comparar
                    if (decimal.TryParse(valor.ToString(), out decimal numero))
                    {
                        // Verifica si está fuera del rango permitido
                        if (numero < rangoAttr.Min || numero > rangoAttr.Max)
                        {
                            errores.Add($"La propiedad '{propiedad.Name}' debe estar entre {rangoAttr.Min} y {rangoAttr.Max}.");
                        }
                    }
                }

                // 🔹 Validación de [Formato]
                var formatoAttr = propiedad.GetCustomAttribute<FormatoAttribute>();
                if (formatoAttr != null && valor is string cadena)
                {
                    // Verifica si el string cumple con el patrón definido por expresión regular
                    if (!Regex.IsMatch(cadena, formatoAttr.Patron))
                    {
                        errores.Add($"La propiedad '{propiedad.Name}' no cumple con el formato requerido.");
                    }
                }
            }

            return errores; // Retorna la lista de errores encontrados
        }
    }
}
