using System;
using System.Collections;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Estructura.Impl
{
    public class Coleccion : IColeccion, IList
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

        public Coleccion(IEnumerable items)
        {
            _col = new List<IObjetoDatos>();

            foreach (var item in items)
                if (item is IObjetoDatos od)
                    _col.Add(od);
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


        #region IList
        int IList.Add(object value)
        {
            return ((IList)_col).Add(value);
        }

        void IList.Clear()
        {
            ((IList)_col).Clear();
        }

        bool IList.Contains(object value)
        {
            return ((IList)_col).Contains(value);
        }

        int IList.IndexOf(object value)
        {
            return ((IList)_col).IndexOf(value);
        }

        void IList.Insert(int index, object value)
        {
            ((IList)_col).Insert(index, value);
        }

        void IList.Remove(object value)
        {
            ((IList)_col).Remove(value);
        }

        void IList.RemoveAt(int index)
        {
            ((IList)_col).RemoveAt(index);
        }

        void ICollection.CopyTo(Array array, int index)
        {
            ((IList)_col).CopyTo(array, index);
        }

        bool IList.IsFixedSize
        {
            get => ((IList)_col).IsFixedSize;
        }

        bool IList.IsReadOnly
        {
            get => ((IList)_col).IsReadOnly;
        }

        int ICollection.Count
        {
            get => ((IList)_col).Count;
        }

        bool ICollection.IsSynchronized
        {
            get => ((IList)_col).IsSynchronized;
        }

        object ICollection.SyncRoot
        {
            get => ((IList)_col).SyncRoot;
        }            

        object IList.this[int index]
        {
            get => ((IList)_col)[index];
            set => ((IList)_col)[index] = value;
        }
        #endregion
    }
}
