using System;
using Binapsis.Plataforma.Estructura;
using System.IO;

namespace Binapsis.Plataforma.Serializacion
{
	public interface ILector
    {
        Stream Stream { get; set; }
        ITipo Tipo { get; }
        
        void Leer(IObjetoDatos od);        
        int LeerId();

        IPropiedad Leer();

		bool LeerBoolean();
		byte LeerByte();
		char LeerChar();
		DateTime LeerDateTime();
		decimal LeerDecimal();
		double LeerDouble();
		float LeerFloat();
		int LeerInteger();
		long LeerLong();
		object LeerObject();
		sbyte LeerSByte();
		short LeerShort();
		string LeerString();
		uint LeerUInteger();
		ulong LeerULong();
		ushort LeerUShort();
        
    } 
}