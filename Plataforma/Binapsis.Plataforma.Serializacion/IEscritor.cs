using System;
using Binapsis.Plataforma.Estructura;
using System.IO;

namespace Binapsis.Plataforma.Serializacion
{
	public interface IEscritor
    {
        Stream Stream { get; set; }

        void Escribir(INodoObjeto objeto);
        void EscribirId(int id);

        void EscribirBoolean(IPropiedad propiedad, bool valor);        
		void EscribirByte(IPropiedad propiedad, byte valor);        
		void EscribirChar(IPropiedad propiedad, char valor);        
		void EscribirDateTime(IPropiedad propiedad, DateTime valor);        
		void EscribirDecimal(IPropiedad propiedad, decimal valor);        
		void EscribirDouble(IPropiedad propiedad, double valor);        
		void EscribirFloat(IPropiedad propiedad, float valor);        
		void EscribirInteger(IPropiedad propiedad, int valor);        
		void EscribirLong(IPropiedad propiedad, long valor);        
		void EscribirObject(IPropiedad propiedad, object valor);
        void EscribirObjetoDatos(IPropiedad propiedad, INodoObjeto valor);
        void EscribirSByte(IPropiedad propiedad, sbyte valor);        
		void EscribirShort(IPropiedad propiedad, short valor);        
		void EscribirString(IPropiedad propiedad, string valor);        
		void EscribirUInteger(IPropiedad propiedad, uint valor);        
		void EscribirULong(IPropiedad propiedad, ulong valor);        
		void EscribirUShort(IPropiedad propiedad, ushort valor);        
    }
}