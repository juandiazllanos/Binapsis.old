using System.Collections;
using System.Collections.Generic;

namespace Binapsis.Consola.Navegacion
{
    public class Elementos : IEnumerable<Elemento>
    {
        List<Elemento> _items;
        Elemento _padre;

        #region Constructores
        public Elementos(Elemento padre)
        {
            _items = new List<Elemento>();
            _padre = padre;
        }
        #endregion


        #region Metodos
        public void Agregar(Elemento elemento)
        {
            if (elemento != null && !_items.Contains(elemento))
            {
                elemento.Padre = _padre;
                _items.Add(elemento);
            }                
        }
        #endregion


        #region IEnumerable
        IEnumerator<Elemento> IEnumerable<Elemento>.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        #endregion
    }
}
