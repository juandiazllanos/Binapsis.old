using System;
using Binapsis.Plataforma.Estructura;
using System.IO;
using Binapsis.Plataforma.Cambios;

namespace Binapsis.Plataforma.Serializacion
{
	public interface ILector
    {
        Stream Stream { get; set; }

        bool Leer();
        int LeerId();
        int LeerItems();
        string LeerRuta();
        Cambio LeerCambio();
        
        IPropiedad Leer(ITipo tipo);
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