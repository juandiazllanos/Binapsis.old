using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Historial.Interno.Estados;
using System;

namespace Binapsis.Plataforma.Historial.Interno
{
    internal static class FabricaEstado
    {
        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, bool valor) => new EstadoBoolean(impl, propiedad, valor);
        
        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, byte valor) => new EstadoByte(impl, propiedad, valor);
        
        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, char valor) => new EstadoChar(impl, propiedad, valor);
        
        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, DateTime valor) => new EstadoDateTime(impl, propiedad, valor);
        
        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, decimal valor) => new EstadoDecimal(impl, propiedad, valor);
        
        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, double valor) => new EstadoDouble(impl, propiedad, valor);
        
        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, float valor) => new EstadoFloat(impl, propiedad, valor);
        
        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, int valor) => new EstadoInteger(impl, propiedad, valor);
        
        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, long valor) => new EstadoLong(impl, propiedad, valor);
        
        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, object valor) => new EstadoObject(impl, propiedad, valor);

        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, IObjetoDatos valor) => new EstadoObjetoDatos(impl, propiedad, valor);

        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, IObjetoDatos valor, int indice) => new EstadoObjetoDatosItem(impl, propiedad, valor, indice);

        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, sbyte valor) => new EstadoSByte(impl, propiedad, valor);

        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, short valor) => new EstadoShort(impl, propiedad, valor);

        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, string valor) => new EstadoString(impl, propiedad, valor);

        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, uint valor) => new EstadoUInteger(impl, propiedad, valor);

        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, ulong valor) => new EstadoULong(impl, propiedad, valor);

        public static HistorialEstado Crear(IImplementacion impl, IPropiedad propiedad, ushort valor) => new EstadoUShort(impl, propiedad, valor);

    }
}
