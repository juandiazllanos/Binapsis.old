using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper;

using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Cambios.Analisis
{
    class ColeccionKeyHelper : IEnumerable<IObjetoDatos>
    {
        List<IObjetoDatos> _itemsCreados;
        List<IObjetoDatos> _itemsEliminados;
        Dictionary<IObjetoDatos, IObjetoDatos> _items;

        #region Constructores
        public ColeccionKeyHelper(IEnumerable<IObjetoDatos> items, IEnumerable<IObjetoDatos> referencia, IKeyHelper keyHelper)
        {
            _itemsCreados = new List<IObjetoDatos>();
            _itemsEliminados = new List<IObjetoDatos>();
            _items = new Dictionary<IObjetoDatos, IObjetoDatos>();

            List<ItemKeyHelper> ikhReferencia = new List<ItemKeyHelper>();

            foreach (var item in referencia)
                ikhReferencia.Add(new ItemKeyHelper(item, keyHelper.GetKey(item)));

            ItemKeyHelper ikhNuevo;
            ItemKeyHelper ikhAntiguo;

            foreach (var item in items)
            {
                ikhNuevo = new ItemKeyHelper(item, keyHelper.GetKey(item));
                ikhAntiguo = ikhReferencia.FirstOrDefault(ikh => ikh.Key?.Equals(ikhNuevo.Key) ?? false);

                // clasificar
                if (ikhAntiguo == null)
                    _itemsCreados.Add(item); // agregar a creados
                else
                    ikhReferencia.Remove(ikhAntiguo); // eliminar de la referencia

                // agregar en items
                _items.Add(item, ikhAntiguo?.Item); 
            }

            // agregar resto en eliminados
            foreach (var ikh in ikhReferencia)
                _itemsEliminados.Add(ikh.Item);

        }
        #endregion


        #region Propiedades
        public IList<IObjetoDatos> Creados
        {
            get => _itemsCreados;
        }

        public IList<IObjetoDatos> Eliminados
        {
            get => _itemsEliminados;
        }

        public IObjetoDatos this[IObjetoDatos od]
        {
            get => _items.ContainsKey(od) ? _items[od] : null;
        }
        #endregion


        #region IEnumerable
        IEnumerator<IObjetoDatos> IEnumerable<IObjetoDatos>.GetEnumerator()
        {
            return _items.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.Keys.GetEnumerator();
        }
        #endregion
    }



    class ItemKeyHelper
    {
        public ItemKeyHelper(IObjetoDatos item, IKey key)
        {
            Item = item;
            Key = key;
        }

        public IObjetoDatos Item
        {
            get;
        }

        public IKey Key
        {
            get;
        }
    }
}
