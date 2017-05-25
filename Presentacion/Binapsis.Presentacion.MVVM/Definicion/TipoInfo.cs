using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;
using System.Reflection;

namespace Binapsis.Presentacion.MVVM.Definicion
{
    public class TipoInfo
    {        
        Dictionary<string, PropiedadInfo> _propiedades;

        public TipoInfo()
        {
            _propiedades = new Dictionary<string, PropiedadInfo>();
        }
        
        public PropiedadInfo CrearPropiedad(string nombre, bool usarReflexion)
        {
            if (!_propiedades.ContainsKey(nombre)) 
                AgregarPropiedad(nombre, usarReflexion);

            return ObtenerPropiedad(nombre);
        }

        public void AgregarPropiedad(string nombre)
        {
            AgregarPropiedad(nombre, UsarReflexion);
        }
        
        public void AgregarPropiedad(string nombre, bool usarReflexion)
        {            
            IPropiedad propiedadItem = Tipo?.ObtenerPropiedad(nombre);
            PropertyInfo propertyItem = Type?.GetDeclaredProperty(nombre);
            if (propiedadItem == null && propertyItem == null) return;

            PropiedadInfo propiedad = new PropiedadInfo(this);
            TipoInfo propiedadTipo = new TipoInfo();

            if (propiedadItem != null)
                propiedadTipo.Nombre = propiedadItem.Tipo.Nombre;
            else if (propertyItem != null)            
                propiedadTipo.Nombre = propertyItem.PropertyType.GetTypeInfo().Name;

            propiedadTipo.Nombre = propiedadItem?.Tipo?.Nombre ?? propertyItem?.PropertyType?.Name;
            propiedadTipo.Tipo = propiedadItem?.Tipo;
            propiedadTipo.Type = propertyItem?.PropertyType?.GetTypeInfo();
            propiedadTipo.UsarReflexion = UsarReflexion;
            
            propiedad.Nombre = nombre;
            propiedad.Propiedad = propiedadItem;
            propiedad.Property = propertyItem;
            propiedad.TipoInfo = propiedadTipo;
            propiedad.UsarReflexion = usarReflexion && propertyItem != null;
            
            AgregarPropiedad(propiedad);

        }

        private void AgregarPropiedad(PropiedadInfo propiedad)
        {
            if (!_propiedades.ContainsKey(propiedad.Nombre)) 
                _propiedades.Add(propiedad.Nombre, propiedad);
        }

        public PropiedadInfo ObtenerPropiedad(string nombre)
        {
            if (_propiedades.ContainsKey(nombre)) 
                return _propiedades[nombre];
            else
                return null;
        }

        public bool EsTipoDeDato
        {
            get
            {
                if (Tipo != null)
                    return Tipo.EsTipoDeDato;
                else if (Type != null)
                    return Type.IsPrimitive;
                else
                    return false;
            }
        }

        public string Nombre
        {
            get;
            set;
        }

        public IEnumerable<PropiedadInfo> Propiedades
        {
            get => _propiedades.Values;
        }

        public PropiedadInfo this[string nombre]
        {
            get => ObtenerPropiedad(nombre);
        }

        public ITipo Tipo
        {
            get;
            set;
        }

        public TypeInfo Type
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
