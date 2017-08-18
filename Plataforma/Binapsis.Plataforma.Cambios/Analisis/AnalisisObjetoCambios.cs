using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Cambios.Analisis
{
    class AnalisisObjetoCambios
    {
        List<AnalisisPropiedadCambios> _propiedades;
        
        public AnalisisObjetoCambios(ITipo tipo)
            : this(tipo, null)
        {

        }

        internal AnalisisObjetoCambios(ITipo tipo, AnalisisObjetoCambios propietario)
        {
            Tipo = tipo;
            Propietario = propietario;
            ClaveHelper = propietario?.ClaveHelper;

            _propiedades = new List<AnalisisPropiedadCambios>();            
        }

        private void Construir()
        {
            foreach (IPropiedad propiedad in Tipo.Propiedades)
                if (propiedad.Tipo.EsTipoDeDato)
                    _propiedades.Add(new AnalisisAtributoCambios(this, propiedad));
                else if (propiedad.EsColeccion)
                    _propiedades.Add(new AnalisisColeccionCambios(this, propiedad));
                else
                    _propiedades.Add(new AnalisisReferenciaCambios(this, propiedad));
        }

        
        public void Resolver()
        {
            Cambio = ResolverCambio(ObjetoDatosNuevo, ObjetoDatosAntiguo);            
        }

        private Cambio ResolverCambio(IObjetoDatos nuevo, IObjetoDatos antiguo)
        {
            if (nuevo == null && antiguo != null)
                return Cambio.Eliminado;

            if (nuevo != null && antiguo == null)
                return Cambio.Creado;

            if (nuevo != null && antiguo != null && !ResolverIgual(nuevo, antiguo))
                return Cambio.Modificado;

            return Cambio.Ninguno;
        }

        private bool ResolverIgual(IObjetoDatos nuevo, IObjetoDatos antiguo)
        {
            bool resul = true;

            Construir();
            
            foreach (AnalisisPropiedadCambios apc in _propiedades)
            { 
                apc.Resolver();
                if (resul) resul = (apc.Cambio == Cambio.Ninguno);
            }
                
            return resul;
        }
        
        public Cambio Cambio
        {
            get;
            set;
        }

        public IClaveHelper ClaveHelper
        {
            get;
            set;
        }

        public IObjetoDatos ObjetoDatosAntiguo
        {
            get;
            set;
        }

        public IObjetoDatos ObjetoDatosNuevo
        {
            get;
            set;
        }

        public IReadOnlyList<AnalisisPropiedadCambios> Propiedades
        {
            get => _propiedades;
        }

        public AnalisisObjetoCambios Propietario
        {
            get;
        }

        public string Ruta
        {
            get;
            set;
        }

        public ITipo Tipo
        {
            get;
        }

    }
}
