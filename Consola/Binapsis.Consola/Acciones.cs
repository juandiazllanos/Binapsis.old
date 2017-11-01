using Binapsis.Consola.Definicion;
using Binapsis.Consola.Estructura;
using System.Collections;
using System.Collections.Generic;

namespace Binapsis.Consola
{
    public class Acciones : IEnumerable<Accion>
    {
        Dictionary<AccionInfo, Accion> _items;
        Pagina _pagina;

        #region Constructores
        public Acciones(Pagina pagina)
        {
            _pagina = pagina;
            _items = new Dictionary<AccionInfo, Accion>();
        }
        #endregion


        #region Metodos
        public Accion Crear(AccionInfo accionInfo)
        {
            Accion accion = Obtener(accionInfo);

            if (accion == null)
                _items.Add(accionInfo, accion = new Accion(_pagina, accionInfo));

            return accion;
        }

        public Accion Obtener(AccionInfo accionInfo)
        {
            if (_items.ContainsKey(accionInfo))
                return _items[accionInfo];
            else
                return null;

        }
        #endregion


        #region Propiedades
        public Accion this[AccionInfo accionInfo]
        {
            get => Obtener(accionInfo);
        }
        #endregion


        #region IEnumerable
        IEnumerator<Accion> IEnumerable<Accion>.GetEnumerator()
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
