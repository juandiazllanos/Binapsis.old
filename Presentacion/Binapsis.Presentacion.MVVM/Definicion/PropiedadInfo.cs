using Binapsis.Plataforma.Estructura;
using System.Collections;
using System.Reflection;

namespace Binapsis.Presentacion.MVVM.Definicion
{
    public class PropiedadInfo
    {
        TipoInfo _propietario;

        public PropiedadInfo(TipoInfo propietario)
        {
            _propietario = propietario;
        }
        
        public bool EsColeccion
        {
            get
            {
                if (Propiedad != null)
                    return Propiedad.EsColeccion;
                else if (Property != null)
                    return typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(Property.PropertyType.GetTypeInfo());
                else
                    return false;
            }
        }
        public string Nombre
        {
            get;
            set;
        }

        public IPropiedad Propiedad
        {
            get;
            set;
        }

        public PropertyInfo Property
        {
            get;
            set;
        }
        
        public TipoInfo TipoInfo
        {
            get;
            set;
        }    
        
        public bool UsarReflexion
        {
            get;
            set;
        }
    }
}
