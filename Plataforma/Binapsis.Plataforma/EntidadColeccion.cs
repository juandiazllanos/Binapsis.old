using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma
{
    public class EntidadColeccion<T> : IEnumerable<T> where T : EntidadBase
    {
        IColeccion _coleccion;
        IObjetoDatos _propietario;
        Propiedad _propiedad;

        #region Constructores
        public EntidadColeccion(EntidadBase propietario, Propiedad propiedad)
        {
            _propietario = propietario;
            _propiedad = propiedad;
            _coleccion = _propietario.ObtenerColeccion(propiedad);
        }
        #endregion


        #region Metodos
        public T Crear()
        {
            return _propietario.CrearObjetoDatos(_propiedad) as T;
        }

        public void Remover(T item)
        {
            _propietario.RemoverObjetoDatos(_propiedad, item);
        }

        public T Obtener(Func<T, bool> predicado)
        {
            return this.FirstOrDefault(predicado);
        }
        #endregion


        #region IEnumerable
        IEnumerator<T> IEnumerable<T>.GetEnumerator() 
        {
            foreach (T item in _coleccion)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _coleccion.GetEnumerator();
        }
        #endregion
        

        #region IColeccion
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

        //IEnumerator<IObjetoDatos> IEnumerable<IObjetoDatos>.GetEnumerator()
        //{
        //    return _coleccion.GetEnumerator();
        //}

        ////IEnumerator IEnumerable.GetEnumerator()
        ////{
        ////    return _coleccion.GetEnumerator();
        ////}

        //int IColeccion.Indice(IObjetoDatos item)
        //{
        //    return _coleccion.Indice(item);
        //}
        #endregion

    }
}
