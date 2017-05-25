using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.MVVM.Definicion;
using System.Reflection;

namespace Binapsis.Presentacion.MVVM.Helper
{
    internal class HelperModelo
    {
        public HelperModelo(IObjetoDatos modelo)
        {
            Modelo = modelo;
        }
        

        public void Establecer(PropiedadInfo propiedad, object valor)
        {
            if (propiedad == null) return;

            if (propiedad.UsarReflexion)
                Establecer(propiedad.Property, valor);
            else 
                Establecer(propiedad.Propiedad, valor);
        }

        private void Establecer(PropertyInfo property, object valor)
        {
            if (Modelo != null)
                property.SetValue(Modelo, valor);
        }

        private void Establecer(IPropiedad propiedad, object valor)
        {
            if (Modelo != null && propiedad != null)
                Modelo.Establecer(propiedad, valor);
        }

        public object Obtener(PropiedadInfo propiedad)
        {
            if (propiedad.UsarReflexion)
                return Obtener(propiedad.Property);            
            else
                return Obtener(propiedad.Propiedad);            
        }

        private object Obtener(PropertyInfo property)
        {
            if (Modelo != null && property != null)
                return property.GetValue(Modelo);
            else
                return null;
        }

        private object Obtener(IPropiedad propiedad)
        {
            if (Modelo == null || propiedad == null) return null;

            if (!propiedad.EsColeccion)
                return Modelo?.Obtener(propiedad);
            else
                return Modelo?.ObtenerColeccion(propiedad);
        }


        public IObjetoDatos Modelo
        {
            get;
        }        
    }
}
