using Binapsis.Consola.Navegacion;
using System.Collections;
using System.Collections.Generic;

namespace Binapsis.Consola.Estructura
{
    public abstract class ColeccionMain<K, T> : IEnumerable<T>
        //where K : Elemento
        //where T : ElementoMain         
    {
        Dictionary<K, T> _items;
        Main _main;

        #region Constructores
        public ColeccionMain(Main main)
        {
            _main = main;
            _items = new Dictionary<K, T>();
        }
        #endregion


        #region Metodos
        protected abstract T Instanciar(K elemento);

        public virtual T Crear(K elemento)
        {
            T item = Obtener(elemento);

            if (item == null)
                _items.Add(elemento, item = Instanciar(elemento));
            
            return item;
        }

        public bool Existe(K elemento)
        {
            return _items.ContainsKey(elemento);
        }

        public virtual T Obtener(K elemento)
        {
            if (_items.ContainsKey(elemento))
                return _items[elemento];
            else
                return default(T);
        }

        public virtual void Remover(K elemento)
        {
            if (_items.ContainsKey(elemento))
                _items.Remove(elemento);
        }
        #endregion


        #region Propiedades
        public T this[K elemento]
        {
            get => Obtener(elemento);
        }

        protected Main Main
        {
            get => _main;
        }
        #endregion


        #region IEnumerable
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _items.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.Values.GetEnumerator();
        }
        #endregion
    }
}
