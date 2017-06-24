using System;
using System.IO;
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Serializacion.Impl
{
    public abstract class LectorBase : ILector
    {
        Stream _stream;
        
        public Stream Stream
        {
            get { return _stream; }
            set { EstablecerStream(value); }
        }
        
        protected virtual void EstablecerStream(Stream stream)
        {
            _stream = stream;
        }
        
        public abstract bool Leer();
        public abstract int LeerId();
        public abstract int LeerItems();
        public abstract string LeerRuta();
        public abstract Cambio LeerCambio();

        public abstract IPropiedad Leer(ITipo tipo);
        public abstract bool LeerBoolean();
        public abstract byte LeerByte();
        public abstract char LeerChar();
        public abstract DateTime LeerDateTime();
        public abstract decimal LeerDecimal();
        public abstract double LeerDouble();
        public abstract float LeerFloat();        
        public abstract int LeerInteger();
        public abstract long LeerLong();
        public abstract object LeerObject();
        public abstract sbyte LeerSByte();
        public abstract short LeerShort();
        public abstract string LeerString();
        public abstract uint LeerUInteger();
        public abstract ulong LeerULong();
        public abstract ushort LeerUShort();
        
    }
}
