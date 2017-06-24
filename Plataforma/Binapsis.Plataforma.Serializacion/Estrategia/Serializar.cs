using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class Serializar
    {
        public Serializar(IEscritor escritor)
        {
            Escritor = escritor;
        }

        public IEscritor Escritor
        {
            get;
        }

        public virtual void Escribir()
        {

        }
                
        protected virtual void EscribirBoolean(IPropiedad propiedad, bool valor)
        {
            Escritor.EscribirBoolean(propiedad, valor);
        }

        protected virtual void EscribirByte(IPropiedad propiedad, byte valor)
        {
            Escritor.EscribirByte(propiedad, valor);
        }

        protected virtual void EscribirChar(IPropiedad propiedad, char valor)
        {
            Escritor.EscribirChar(propiedad, valor);
        }
        protected virtual void EscribirDateTime(IPropiedad propiedad, DateTime valor)
        {
            Escritor.EscribirDateTime(propiedad, valor);
        }

        protected virtual void EscribirDecimal(IPropiedad propiedad, decimal valor)
        {
            Escritor.EscribirDecimal(propiedad, valor);
        }

        protected virtual void EscribirDouble(IPropiedad propiedad, double valor)
        {
            Escritor.EscribirDouble(propiedad, valor);
        }

        protected virtual void EscribirFloat(IPropiedad propiedad, float valor)
        {
            Escritor.EscribirFloat(propiedad, valor);
        }

        protected virtual void EscribirInteger(IPropiedad propiedad, int valor)
        {
            Escritor.EscribirInteger(propiedad, valor);
        }

        protected virtual void EscribirLong(IPropiedad propiedad, long valor)
        {
            Escritor.EscribirLong(propiedad, valor);
        }

        protected virtual void EscribirObject(IPropiedad propiedad, object valor)
        {
            Escritor.EscribirObject(propiedad, valor);
        }
        
        protected virtual void EscribirSByte(IPropiedad propiedad, sbyte valor)
        {
            Escritor.EscribirSByte(propiedad, valor);
        }

        protected virtual void EscribirShort(IPropiedad propiedad, short valor)
        {
            Escritor.EscribirShort(propiedad, valor);
        }

        protected virtual void EscribirString(IPropiedad propiedad, string valor)
        {
            Escritor.EscribirString(propiedad, valor);
        }

        protected virtual void EscribirUInteger(IPropiedad propiedad, uint valor)
        {
            Escritor.EscribirUInteger(propiedad, valor);
        }

        protected virtual void EscribirULong(IPropiedad propiedad, ulong valor)
        {
            Escritor.EscribirULong(propiedad, valor);
        }

        protected virtual void EscribirUShort(IPropiedad propiedad, ushort valor)
        {
            Escritor.EscribirUShort(propiedad, valor);
        }
    }
}
