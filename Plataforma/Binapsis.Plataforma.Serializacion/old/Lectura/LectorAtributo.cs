using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Helpers;
using System;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion.Lectura
{
    internal static class LectorAtributo
    {
        static Dictionary<Type, Action<ILector, IObjetoDatos, IPropiedad>> _delegados;

        static LectorAtributo()
        {
            _delegados = new Dictionary<Type, Action<ILector, IObjetoDatos, IPropiedad>>(16);

            _delegados[typeof(bool)] = (lector, od, propiedad) => od.EstablecerBoolean(propiedad, lector.LeerAtributoBoolean(propiedad));
            _delegados[typeof(byte)] = (lector, od, propiedad) => od.EstablecerByte(propiedad, lector.LeerAtributoByte(propiedad));
            _delegados[typeof(char)] = (lector, od, propiedad) => od.EstablecerChar(propiedad, lector.LeerAtributoChar(propiedad));
            _delegados[typeof(DateTime)] = (lector, od, propiedad) => od.EstablecerDateTime(propiedad, lector.LeerAtributoDateTime(propiedad));
            _delegados[typeof(decimal)] = (lector, od, propiedad) => od.EstablecerDecimal(propiedad, lector.LeerAtributoDecimal(propiedad));
            _delegados[typeof(double)] = (lector, od, propiedad) => od.EstablecerDouble(propiedad, lector.LeerAtributoDouble(propiedad));
            _delegados[typeof(float)] = (lector, od, propiedad) => od.EstablecerFloat(propiedad, lector.LeerAtributoFloat(propiedad));
            _delegados[typeof(int)] = (lector, od, propiedad) => od.EstablecerInteger(propiedad, lector.LeerAtributoInteger(propiedad));
            _delegados[typeof(long)] = (lector, od, propiedad) => od.EstablecerLong(propiedad, lector.LeerAtributoLong(propiedad));
            _delegados[typeof(object)] = (lector, od, propiedad) => od.EstablecerObject(propiedad, lector.LeerAtributoObject(propiedad));
            _delegados[typeof(sbyte)] = (lector, od, propiedad) => od.EstablecerSByte(propiedad, lector.LeerAtributoSByte(propiedad));
            _delegados[typeof(short)] = (lector, od, propiedad) => od.EstablecerShort(propiedad, lector.LeerAtributoShort(propiedad));
            _delegados[typeof(string)] = (lector, od, propiedad) => od.EstablecerString(propiedad, lector.LeerAtributoString(propiedad));
            _delegados[typeof(uint)] = (lector, od, propiedad) => od.EstablecerUInteger(propiedad, lector.LeerAtributoUInteger(propiedad));
            _delegados[typeof(ulong)] = (lector, od, propiedad) => od.EstablecerULong(propiedad, lector.LeerAtributoULong(propiedad));
            _delegados[typeof(ushort)] = (lector, od, propiedad) => od.EstablecerUShort(propiedad, lector.LeerAtributoUShort(propiedad));
        }

        public static void Leer(ILector lector, IObjetoDatos od, IPropiedad propiedad)
        {
            _delegados[TipoHelper.ObtenerType(propiedad.Tipo)].Invoke(lector, od, propiedad);
        }

    }
}
