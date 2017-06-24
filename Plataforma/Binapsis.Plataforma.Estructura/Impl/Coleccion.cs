using System;
using System.Collections;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Estructura.Impl
{
    public class Coleccion : IColeccion
    {
        List<IObjetoDatos> _col;

        #region Constructores
        public Coleccion()
        {
            _col = new List<IObjetoDatos>();
        }

        public Coleccion(IEnumerable<IObjetoDatos> items)
        {
            _col = new List<IObjetoDatos>(items);
        }
        #endregion


        #region Propiedades
        public IObjetoDatos this[int indice]
        {
            get => _col[indice];
            set => _col[indice] = value;
        }

        public int Longitud
        {
            get => _col.Count;
        }
        #endregion


        #region Metodos
        public IObjetoDatos Agregar(IObjetoDatos item)
        {
            if (item != null)
                _col.Add(item);

            return item;
        }

        public void Agregar(IEnumerable<IObjetoDatos> items)
        {
            if (items == null) return;
            _col.AddRange(items);
        }
        
        public bool Contiene(IObjetoDatos item)
        {
            if (item == null)
                return false;
            else 
                return _col.Contains(item);
        }

        public void ForEach(Action<IObjetoDatos> accion)
        {
            _col.ForEach(accion);
        }

        public int Indice(IObjetoDatos item)
        {
            return _col.IndexOf(item);
        }

        public void Remover(IObjetoDatos item)
        {
            if (Contiene(item))
                _col.Remove(item);
        }

        public void Remover(IEnumerable<IObjetoDatos> items)
        {
            if (items == null) return;

            foreach (IObjetoDatos item in items)
                Remover(item);
        }

        public void Remover(int indice)
        {
            if (indice > 0 && _col.Count < indice)
                _col.RemoveAt(indice);
        }

        public void RemoverTodo()
        {
            _col.Clear();
        }
        #endregion


        #region IEnumerable
        public IEnumerator<IObjetoDatos> GetEnumerator()
        {
            return _col.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
