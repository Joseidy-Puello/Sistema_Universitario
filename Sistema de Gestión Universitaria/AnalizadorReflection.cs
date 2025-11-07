using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Universitario
{
    public class AnalizadorReflection
    {
        // Lista todas las propiedades públicas con su tipo
        public static void MostrarPropiedades(Type tipo)
        {
            Console.WriteLine($"🔍 Propiedades de {tipo.Name}:");
            foreach (PropertyInfo prop in tipo.GetProperties())
            {
                Console.WriteLine($"- {prop.Name} : {prop.PropertyType.Name}");
            }
        }

        // Lista todos los métodos públicos
        public static void MostrarMetodos(Type tipo)
        {
            Console.WriteLine($"\n🔧 Métodos públicos de {tipo.Name}:");
            foreach (MethodInfo metodo in tipo.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                string parametros = string.Join(", ", metodo.GetParameters()
                    .Select(p => $"{p.ParameterType.Name} {p.Name}"));
                Console.WriteLine($"- {metodo.Name}({parametros}) : {metodo.ReturnType.Name}");
            }
        }

        // Crea una instancia dinámica del tipo especificado
        public static object CrearInstanciaDinamica(Type tipo, params object[] parametros)
        {
            object instancia = Activator.CreateInstance(tipo, parametros);
            Console.WriteLine($"\n✅ Instancia de {tipo.Name} creada dinámicamente.");
            return instancia;
        }

        // Invoca un método por nombre en una instancia
        public static object InvocarMetodo(object instancia, string nombreMetodo, params object[] parametros)
        {
            Type tipo = instancia.GetType();
            MethodInfo metodo = tipo.GetMethod(nombreMetodo);

            if (metodo == null)
                throw new InvalidOperationException($"El método '{nombreMetodo}' no existe en {tipo.Name}.");

            object resultado = metodo.Invoke(instancia, parametros);
            Console.WriteLine($"\n🚀 Método '{nombreMetodo}' invocado en {tipo.Name}.");
            return resultado;
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class ValidacionRangoAttribute : Attribute
        {
            public decimal Min { get; }
            public decimal Max { get; }

            public ValidacionRangoAttribute(double min, double max)
            {
                Min = (decimal)min;
                Max = (decimal)max;
            }
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class RequeridoAttribute : Attribute
        {
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class FormatoAttribute : Attribute
        {
            public string Patron { get; }

            public FormatoAttribute(string patron)
            {
                Patron = patron;
            }
        }



    }
}
