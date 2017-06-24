using System;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;
using Binapsis.Plataforma.Estructura.Impl;
using System.Linq;
using System.Reflection;

namespace Binapsis.Plataforma.Cambios.Impl
{
    public class ResumenCambios : IResumenCambios
    {
        Dictionary<IObjetoDatos, IObjetoCambios> _creados;
        Dictionary<IObjetoDatos, IObjetoCambios> _eliminados;
        Dictionary<IObjetoDatos, IObjetoCambios> _modificados;
        Coleccion _cambiados;

        #region Constructores
        public ResumenCambios()
        {
            _cambiados = new Coleccion();
            _creados = new Dictionary<IObjetoDatos, IObjetoCambios>();
            _eliminados = new Dictionary<IObjetoDatos, IObjetoCambios>();
            _modificados = new Dictionary<IObjetoDatos, IObjetoCambios>();            
        }
        #endregion


        #region Metodos
        public bool Creado(IObjetoDatos od)
        {
            return _creados.ContainsKey(od);
        }

        public bool Eliminado(IObjetoDatos od)
        {
            return _eliminados.ContainsKey(od);
        }

        public bool Modificado(IObjetoDatos od)
        {
            return _modificados.ContainsKey(od);
        }
                
        public IColeccion ObtenerObjetoDatosCambiados()
        {
            return _cambiados;
        }

        public IEnumerable<IPropiedad> ObtenerCambios(IObjetoDatos od)
        {   
            if (!Modificado(od)) yield break;
            IObjetoCambios cambios = _modificados[od];

            var propiedades = cambios.Tipo.Propiedades.Where(propiedad => cambios.Establecido(propiedad));

            foreach (IPropiedad propiedad in propiedades)            
                yield return propiedad;
        }

        public object ObtenerValorAntiguo(IObjetoDatos od, IPropiedad propiedad)
        {
            if (!Modificado(od)) return null;

            object valor = _modificados[od].Obtener(propiedad);

            if (!propiedad.Tipo.EsTipoDeDato && valor != null && 
               typeof(IObjetoCambios).GetTypeInfo().IsAssignableFrom(valor.GetType().GetTypeInfo()) && 
               (valor as IObjetoCambios).Cambio == Cambio.Creado)
                return null;
            else 
                return valor;
        }
        private IObjetoCambios ObtenerObjetoCambios(IObjetoDatos od)
        {
            if (Modificado(od))
                return _modificados[od];

            if (Creado(od))
                return _creados[od];

            if (Eliminado(od))
                return _eliminados[od];

            return null;
        }

        internal void Agregar(IObjetoDatos datos, IObjetoCambios cambios)
        {
            if (cambios.Cambio != Cambio.Ninguno)
                _cambiados.Agregar(datos);

            if (cambios.Cambio == Cambio.Creado)
                _creados.Add(datos, cambios);
            else if (cambios.Cambio == Cambio.Modificado)
                _modificados.Add(datos, cambios);
            else if (cambios.Cambio == Cambio.Eliminado)
                _eliminados.Add(datos, cambios);
        }
        #endregion


        #region Propiedades
        public IObjetoCambios this[IObjetoDatos od]
        {
            get => ObtenerObjetoCambios(od);
        }
        #endregion
    }
}
