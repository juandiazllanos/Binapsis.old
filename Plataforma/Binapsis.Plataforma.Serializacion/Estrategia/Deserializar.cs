using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion.Interno;
using System;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class Deserializar
    {
        public Deserializar(ILector lector)
        {
            Lector = lector;
        }

        public ILector Lector
        {
            get;
        }

        public HeapId HeapId
        {
            get;
            set;
        }

        public IFabrica Fabrica
        {
            get;
            set;
        }

        public virtual void Leer()
        {

        }

        public virtual int LeerId()
        {
            return Lector.LeerId();
        }

        public virtual bool LeerBoolean()
        {
            return Lector.LeerBoolean();
        }

        public virtual byte LeerByte()
        {
            return Lector.LeerByte();
        }

        public virtual char LeerChar()
        {
            return Lector.LeerChar();
        }

        public virtual DateTime LeerDateTime()
        {
            return Lector.LeerDateTime();
        }

        public virtual decimal LeerDecimal()
        {
            return Lector.LeerDecimal();
        }

        public virtual double LeerDouble()
        {
            return Lector.LeerDouble();
        }

        public virtual float LeerFloat()
        {
            return Lector.LeerFloat();
        }

        public virtual int LeerInteger()
        {
            return Lector.LeerInteger();
        }

        public virtual long LeerLong()
        {
            return Lector.LeerLong();
        }

        public virtual object LeerObject()
        {
            return Lector.LeerObject();
        }

        public virtual sbyte LeerSByte()
        {
            return Lector.LeerSByte();
        }

        public virtual short LeerShort()
        {
            return Lector.LeerShort();
        }

        public virtual string LeerString()
        {
            return Lector.LeerString();
        }

        public virtual uint LeerUInteger()
        {
            return Lector.LeerUInteger();
        }

        public virtual ulong LeerULong()
        {
            return Lector.LeerULong();
        }

        public virtual ushort LeerUShort()
        {
            return Lector.LeerUShort();
        }
    }
}
