using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Universitario
{
    
    // Delegado para criterios de búsqueda
    public delegate bool CriterioBusqueda<T>(T elemento) where T : IIdentificable;

    // Delegado para acciones sobre elementos
    public delegate void AccionElemento<T>(T elemento) where T : IIdentificable;

    public class Repositorio<T> where T : IIdentificable
    {
        private List<T> elementos = new List<T>();

        // Agrega un elemento a la colección
        public void Agregar(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (string.IsNullOrEmpty(item.Identificacion))
                throw new ArgumentException("El elemento debe tener un ID válido", nameof(item));

            elementos.Add(item);
        }

        // Elimina un elemento por su ID
        public bool Eliminar(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("El ID no puede ser nulo o vacío", nameof(id));

            var elemento = elementos.FirstOrDefault(e => e.Identificacion == id);
            if (elemento != null)
                return elementos.Remove(elemento);

            return false;
        }


        // Busca un elemento por su ID
        public T BuscarPorId(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("El ID no puede ser nulo o vacío", nameof(id));

            return elementos.Find(e => e.Identificacion == id);
        }

        // Busca un elemento que cumpla con el criterio
        public T Buscar(CriterioBusqueda<T> criterio)
        {
            if (criterio == null)
                throw new ArgumentNullException(nameof(criterio));

            foreach (var elemento in elementos)
            {
                if (criterio(elemento))
                    return elemento;
            }
            return default(T);
        }

        // Busca todos los elementos que cumplan con el criterio
        public List<T> ObtenerTodos(CriterioBusqueda<T> criterio = null)
        {
            if (criterio == null)
                return new List<T>(elementos); // Devuelve una copia de todos los elementos

            var resultados = new List<T>();
            foreach (var elemento in elementos)
            {
                if (criterio(elemento))
                    resultados.Add(elemento);
            }
            return resultados;
        }

        // Aplica una acción a cada elemento de la colección
        public void ParaCada(AccionElemento<T> accion)
        {
            if (accion == null)
                throw new ArgumentNullException(nameof(accion));

            foreach (var elemento in elementos)
            {
                accion(elemento);
            }
        }

        // Propiedad para obtener la cantidad de elementos
        public int Cantidad => elementos.Count;

        // Indexador para acceder a los elementos por índice
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= elementos.Count)
                    throw new IndexOutOfRangeException("Índice fuera de rango");
                return elementos[index];
            }
        }
    }
}
