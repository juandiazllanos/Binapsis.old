using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.MVVM.Definicion;
using System.Collections.Generic;

namespace Binapsis.Presentacion.MVVM.Interno
{
    class VistaModeloTipo
    {
        Dictionary<PropiedadInfo, VistaModeloPropiedad> _contenido;

        public VistaModeloTipo(Vista vista)
        {            
            _contenido = new Dictionary<PropiedadInfo, VistaModeloPropiedad>();
            Establecer(vista);
        }

        private void Establecer(Vista vista)
        {
            Vista = vista;
            TipoInfo = Vista.TipoInfo;          
        }
        
        public void Agregar(PropiedadInfo propiedad, IObjetoDatos modelo)
        {
            if (!Existe(propiedad))
                _contenido.Add(propiedad, new VistaModeloColeccion(Vista, propiedad));

            _contenido[propiedad].Agregar(modelo);
        }

        public void Establecer(PropiedadInfo propiedad, IObjetoDatos modelo)
        {
            if (!Existe(propiedad))
                _contenido.Add(propiedad, new VistaModeloReferencia(Vista, propiedad));

            _contenido[propiedad].Establecer(modelo);
        }

        public bool Existe(PropiedadInfo propiedad)
        {
            return _contenido.ContainsKey(propiedad);
        }

        public VistaModelo Obtener(PropiedadInfo propiedad)
        {
            if (Existe(propiedad))
                return _contenido[propiedad].Obtener();
            else
                return null;
        }

        public VistaModelo Obtener(PropiedadInfo propiedad, IObjetoDatos modelo)
        {
            if (Existe(propiedad))
                return _contenido[propiedad].Obtener(modelo);
            else
                return null;
        }

        public IEnumerable<VistaModelo> ObtenerColeccion(PropiedadInfo propiedad)
        {
            return ((VistaModeloColeccion)_contenido[propiedad]);
        }
        
        public void Remover(PropiedadInfo propiedad, IObjetoDatos modelo)
        {
            if (Existe(propiedad))
                _contenido[propiedad].Remover(modelo);
        }


        #region Propiedades
        public Vista Vista
        {
            get;
            private set;
        }
                
        public TipoInfo TipoInfo
        {
            get;
            private set;
        }
        #endregion
    }
}
