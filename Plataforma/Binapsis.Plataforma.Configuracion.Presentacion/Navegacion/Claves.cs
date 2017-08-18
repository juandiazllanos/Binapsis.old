using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;
using System.Collections;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Navegacion
{
    public class Claves : IEnumerable<Clave>
    {
        List<Clave> _items;

        public Claves()
        {
            _items = new List<Clave>();
        }

        public Claves(IColeccion coleccion)
            : this()
        {
            foreach (IObjetoDatos od in coleccion)
                _items.Add(new Clave(od) { Nombre = od.ObtenerString("Nombre") } );
        }

        IEnumerator<Clave> IEnumerable<Clave>.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        //IObjetoDatos IColeccion.this[int indice]
        //{
        //    get => _coleccion[indice];
        //}

        //int IColeccion.Longitud
        //{
        //    get => _coleccion.Longitud;
        //}

        //bool IColeccion.Contiene(IObjetoDatos item)
        //{
        //    return _coleccion.Contiene(item);
        //}

        //int IColeccion.Indice(IObjetoDatos item)
        //{
        //    return _coleccion.Indice(item);
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return _coleccion.GetEnumerator();
        //}

        //IEnumerator<IObjetoDatos> IEnumerable<IObjetoDatos>.GetEnumerator()
        //{
        //    return _coleccion.GetEnumerator();
        //}
    }
}
