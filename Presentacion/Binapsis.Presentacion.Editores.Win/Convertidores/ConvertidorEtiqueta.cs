using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace Binapsis.Presentacion.Editores.Win.Convertidores
{
    internal class ConvertidorEtiqueta : ExpandableObjectConverter
    {

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if ((destinationType == typeof(string)) && (value != null) && (typeof(Etiqueta).IsAssignableFrom(value.GetType())))
                return string.Format("Texto={0}", ((Etiqueta)value).Texto);

            if (destinationType == typeof(InstanceDescriptor))
                return new InstanceDescriptor(typeof(Etiqueta).GetConstructor(new Type[] { }), null);

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
