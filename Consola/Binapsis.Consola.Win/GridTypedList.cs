using Binapsis.Consola.Definicion;
using Binapsis.Plataforma.Estructura;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;

namespace Binapsis.Consola.Win
{
    public class GridTypedList : ITypedList, IList
    {
        PropertyDescriptor[] _pds;        
        IList _items;
        ContenidoInfo _contenidoInfo;

        public GridTypedList(ContenidoInfo contenidoInfo, ITipo tipo, IEnumerable items)
        {
            if (items is IList list)
                _items = list;
            else
                _items = items.Cast<IObjetoDatos>().ToList();

            _contenidoInfo = contenidoInfo;

            ConstruirPropertyDescriptor(tipo);
        }

        public GridTypedList(ContenidoInfo contenidoInfo, ITipo tipo, IList items)
        {
            _items = items;
            _contenidoInfo = contenidoInfo;

            ConstruirPropertyDescriptor(tipo);
        }

        private void ConstruirPropertyDescriptor(ITipo tipo)
        {
            int longitud = _contenidoInfo.Columnas.Longitud;
            _pds = new PropertyDescriptor[longitud];
            
            ColumnaInfo columnaInfo = null;
            IPropiedad propiedad = null;

            for (int i = 0; i < longitud; i++)
            {
                columnaInfo = _contenidoInfo.Columnas[i];
                propiedad = tipo.ObtenerPropiedad(columnaInfo.Nombre);

                if (propiedad != null)
                    _pds[i] = new GridPropertyDescriptor(propiedad, ObtenerType(propiedad));
                else
                    _pds[i] = new GridPropertyDescriptor(columnaInfo.Nombre, null, typeof(string));
            }
                
        }

        private Type ObtenerType(IPropiedad propiedad)
        {
            switch (propiedad.Tipo.Nombre)
            {
                case "Boolean":
                    return typeof(Boolean);
                case "Char":
                    return typeof(Char);
                case "DateTime":
                    return typeof(DateTime);
                case "Decimal":
                    return typeof(Decimal);
                case "Double":
                    return typeof(Double);
                case "Int16":
                    return typeof(Int16);
                case "Int32":
                    return typeof(Int32);
                case "Int64":
                    return typeof(Int64);
                case "Object":
                    return typeof(Object);
                case "SByte":
                    return typeof(SByte);
                case "Single":
                    return typeof(Single);
                case "String":
                    return typeof(String);
                case "UInt16":
                    return typeof(UInt16);
                case "UInt32":
                    return typeof(UInt32);
                case "UInt64":
                    return typeof(UInt64);
                default:
                    return null;
            }
        }

        #region ITypedList
        PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            return new PropertyDescriptorCollection(_pds);
        }

        string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
        {
            return "";
        }
        #endregion


        #region IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        #endregion


        #region IList
        bool IList.IsReadOnly => true;
        bool IList.IsFixedSize => true;
        object IList.this[int index] { get => _items[index]; set { } }
        
        int IList.Add(object value) => 0;
        bool IList.Contains(object value) => true;        
        void IList.Clear() { }
        int IList.IndexOf(object value) => 0;
        void IList.Insert(int index, object value) { }
        void IList.Remove(object value) { }
        void IList.RemoveAt(int index) { }
        #endregion


        #region ICollection
        int ICollection.Count => _items.Count;
        object ICollection.SyncRoot => _items.SyncRoot;
        bool ICollection.IsSynchronized => _items.IsSynchronized;

        void ICollection.CopyTo(Array array, int index) { }
        #endregion

    }
}
