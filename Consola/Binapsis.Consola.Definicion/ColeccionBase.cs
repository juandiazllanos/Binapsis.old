using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Consola.Definicion
{
    public abstract class ColeccionBase<T> : IEnumerable<T> where T : DefinicionBase
    {
        List<T> _items = new List<T>();

        public  T Crear(string nombre)
        {
            Agregar(Instanciar(nombre));
            return Obtener(nombre);
        }

        protected abstract T Instanciar(string nombre);

        public void Agregar(T item)
        {
            if (!Existe(item.Nombre))
                _items.Add(item);
        }

        public bool Existe(string nombre)
        {
            return _items.Exists(item => item.Nombre == nombre);
        }

        public T Obtener(string nombre)
        {
            return _items.FirstOrDefault(item => item.Nombre == nombre);
        }

        public T this[string nombre]
        {
            get => Obtener(nombre);
        }

        public T this[int indice]
        {
            get => indice < _items.Count ? _items[indice] : null;
        }

        public int Longitud
        {
            get => _items.Count;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
