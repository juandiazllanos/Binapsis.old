using Binapsis.Plataforma.Estructura;
using System;
using System.ComponentModel;

namespace Binapsis.Consola.Win
{
    class GridPropertyDescriptor : PropertyDescriptor
    {
        IPropiedad _propiedad;
        Type _type;

        #region Constructores
        public GridPropertyDescriptor(IPropiedad propiedad, Type type)
            : this(propiedad.Nombre, propiedad, type)
        {
        }

        public GridPropertyDescriptor(string nombre, IPropiedad propiedad, Type type) 
            : base(nombre, null)
        {
            _propiedad = propiedad;
            _type = type;
        }
        #endregion

        
        public override Type ComponentType => typeof(IObjetoDatos);
        public override bool IsReadOnly => true;
        public override Type PropertyType => _type;

        public override object GetValue(object component) => _propiedad != null ? (component as IObjetoDatos)?.Obtener(_propiedad) : null;
        public override bool CanResetValue(object component) => false;
        public override void ResetValue(object component) { }
        public override void SetValue(object component, object value) { }
        public override bool ShouldSerializeValue(object component) => false;
    }
}
