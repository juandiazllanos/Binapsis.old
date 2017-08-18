using System.Collections;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Navegacion
{
    public class Nodos : IEnumerable<Nodo>
    {
        List<Nodo> _items;

        internal Nodos(Nodo propietario)
        {
            Propietario = propietario;
            _items = new List<Nodo>();
        }
        
        internal void Agregar(Nodo nodo)
        {
            _items.Add(nodo);
            nodo.Padre = Propietario;
        }

        internal void Remover(int indice)
        {
            if (indice >= 0 && indice < _items.Count)
                _items.RemoveAt(indice);
        }

        internal void Remover(Nodo nodo)
        {
            _items.Remove(nodo);
        }

        internal void RemoverTodo()
        {
            _items.Clear();
        }

        public int Longitud
        {
            get => _items.Count;
        }

        private Nodo Propietario
        {
            get;
        }

        #region IEnumerable
        public IEnumerator<Nodo> GetEnumerator()
        {
            return ((IEnumerable<Nodo>)_items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Nodo>)_items).GetEnumerator();
        }
        #endregion
    }
}
