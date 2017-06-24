using System;
using System.IO;
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Serializacion.Impl
{
    public abstract class EscritorBase : IEscritor
    {
        Stream _strm;
        
        public virtual Stream Stream
        {
            get { return _strm; }
            set { EstablecerStream(value); }
        }

        protected virtual void EstablecerStream(Stream stream)
        {
            _strm = stream;
        }

        public abstract void EscribirColeccion(int items);
        public abstract void EscribirColeccionCierre();
        public abstract void EscribirDiagramaDatos();
        public abstract void EscribirDiagramaDatosCierre();
        public abstract void EscribirObjetoDatos(ITipo tipo, int id);        
        public abstract void EscribirObjetoDatos(ITipo tipo, int id, string ruta, Cambio cambio);
        public abstract void EscribirObjetoDatos(IPropiedad propiedad, int id);
        public abstract void EscribirObjetoDatos(IPropiedad propiedad, int id, string ruta, Cambio cambio);        
        public abstract void EscribirObjetoDatosCierre();

        public abstract void EscribirBoolean(IPropiedad propiedad, bool valor);
        public abstract void EscribirByte(IPropiedad propiedad, byte valor);
        public abstract void EscribirChar(IPropiedad propiedad, char valor);
        public abstract void EscribirDateTime(IPropiedad propiedad, DateTime valor);
        public abstract void EscribirDecimal(IPropiedad propiedad, decimal valor);
        public abstract void EscribirDouble(IPropiedad propiedad, double valor);
        public abstract void EscribirFloat(IPropiedad propiedad, float valor);        
        public abstract void EscribirInteger(IPropiedad propiedad, int valor);
        public abstract void EscribirLong(IPropiedad propiedad, long valor);
        public abstract void EscribirObject(IPropiedad propiedad, object valor);        
        public abstract void EscribirSByte(IPropiedad propiedad, sbyte valor);
        public abstract void EscribirShort(IPropiedad propiedad, short valor);
        public abstract void EscribirString(IPropiedad propiedad, string valor);
        public abstract void EscribirUInteger(IPropiedad propiedad, uint valor);
        public abstract void EscribirULong(IPropiedad propiedad, ulong valor);
        public abstract void EscribirUShort(IPropiedad propiedad, ushort valor);
        
    }
}
