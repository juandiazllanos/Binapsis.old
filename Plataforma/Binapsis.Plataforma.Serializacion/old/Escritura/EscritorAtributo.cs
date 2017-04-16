using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Helpers;
using System;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Serializacion.Escritura
{
    internal static class EscritorAtributo
    {
        static Dictionary<Type, Action<IEscritor, IObjetoDatos, IPropiedad>> _delegados;

        static EscritorAtributo()
        {
            _delegados = new Dictionary<Type, Action<IEscritor, IObjetoDatos, IPropiedad>>(16);

            _delegados[typeof(bool)] = (escritor, od, propiedad) => escritor.EscribirAtributoBoolean(propiedad, od.ObtenerBoolean(propiedad));
            _delegados[typeof(byte)] = (escritor, od, propiedad) => escritor.EscribirAtributoByte(propiedad, od.ObtenerByte(propiedad));
            _delegados[typeof(char)] = (escritor, od, propiedad) => escritor.EscribirAtributoChar(propiedad, od.ObtenerChar(propiedad));
            _delegados[typeof(DateTime)] = (escritor, od, propiedad) => escritor.EscribirAtributoDateTime(propiedad, od.ObtenerDateTime(propiedad));
            _delegados[typeof(decimal)] = (escritor, od, propiedad) => escritor.EscribirAtributoDecimal(propiedad, od.ObtenerDecimal(propiedad));
            _delegados[typeof(double)] = (escritor, od, propiedad) => escritor.EscribirAtributoDouble(propiedad, od.ObtenerDouble(propiedad));
            _delegados[typeof(float)] = (escritor, od, propiedad) => escritor.EscribirAtributoFloat(propiedad, od.ObtenerFloat(propiedad));
            _delegados[typeof(int)] = (escritor, od, propiedad) => escritor.EscribirAtributoInteger(propiedad, od.ObtenerInteger(propiedad));
            _delegados[typeof(long)] = (escritor, od, propiedad) => escritor.EscribirAtributoLong(propiedad, od.ObtenerLong(propiedad));
            _delegados[typeof(object)] = (escritor, od, propiedad) => escritor.EscribirAtributoObject(propiedad, od.ObtenerObject(propiedad));
            _delegados[typeof(sbyte)] = (escritor, od, propiedad) => escritor.EscribirAtributoSByte(propiedad, od.ObtenerSByte(propiedad));
            _delegados[typeof(short)] = (escritor, od, propiedad) => escritor.EscribirAtributoShort(propiedad, od.ObtenerShort(propiedad));
            _delegados[typeof(string)] = (escritor, od, propiedad) => escritor.EscribirAtributoString(propiedad, od.ObtenerString(propiedad));
            _delegados[typeof(uint)] = (escritor, od, propiedad) => escritor.EscribirAtributoUInteger(propiedad, od.ObtenerUInteger(propiedad));
            _delegados[typeof(ulong)] = (escritor, od, propiedad) => escritor.EscribirAtributoULong(propiedad, od.ObtenerULong(propiedad));
            _delegados[typeof(ushort)] = (escritor, od, propiedad) => escritor.EscribirAtributoUShort(propiedad, od.ObtenerUShort(propiedad));
        }

        public static void Escribir(IEscritor escritor, IObjetoDatos od, IPropiedad propiedad)
        {
            _delegados[TipoHelper.ObtenerType(propiedad.Tipo)].Invoke(escritor, od, propiedad);
        }
    }
}
