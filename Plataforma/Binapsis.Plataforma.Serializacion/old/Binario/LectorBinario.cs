using System;
using System.IO;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Serializacion.Binario
{
    public class LectorBinario : ILector
    {
        BinaryReader _reader;
        Stream _stream;

        public void Abrir(Stream stream)
        {
            _reader = new BinaryReader(stream);
            _stream = stream;
        }

        public void Cerrar()
        {
            if (_reader != null)
            {
                _reader.Dispose();
                _reader = null;
            }

            if (_stream != null)
            {
                _stream.Dispose();
                _stream = null;
            }
        }
        
        public IPropiedad Leer(ITipo contexto)
        {
            int indice = _reader.ReadInt32();
            return contexto?[indice];
        }

        public byte LeerMetodo()
        {
            if (_reader.BaseStream.Position < _reader.BaseStream.Length)
                return _reader.ReadByte();
            else
                return 0;
        }

        public int LeerMetodoIdentidad()
        {
            return _reader.ReadUInt16();
        }

        public int LeerMetodoLongitud()
        {
            return _reader.ReadSByte();
        }

        public int LeerMetodoPropietario()
        {
            return _reader.ReadUInt16();
        }

        public int LeerMetodoPropiedad()
        {
            return _reader.ReadSByte();
        }

        public string LeerMetodoUri()
        {
            return _reader.ReadString();
        }

        public string LeerMetodoTipo()
        {
            return _reader.ReadString();
        }

        public bool LeerAtributoBoolean(IPropiedad propiedad)
        {
            return _reader.ReadBoolean();
        }

        public byte LeerAtributoByte(IPropiedad propiedad)
        {
            return _reader.ReadByte();
        }

        public char LeerAtributoChar(IPropiedad propiedad)
        {
            return _reader.ReadChar();
        }

        public DateTime LeerAtributoDateTime(IPropiedad propiedad)
        {
            return new DateTime(_reader.ReadInt64());
        }

        public decimal LeerAtributoDecimal(IPropiedad propiedad)
        {
            return _reader.ReadDecimal();
        }

        public double LeerAtributoDouble(IPropiedad propiedad)
        {
            return _reader.ReadDouble();
        }

        public float LeerAtributoFloat(IPropiedad propiedad)
        {
            return _reader.ReadSingle(); 
        }

        public int LeerAtributoInteger(IPropiedad propiedad)
        {
            return _reader.ReadInt32();
        }

        public long LeerAtributoLong(IPropiedad propiedad)
        {
            return _reader.ReadInt64();
        }

        public object LeerAtributoObject(IPropiedad propiedad)
        {
            return null;
        }

        public sbyte LeerAtributoSByte(IPropiedad propiedad)
        {
            return _reader.ReadSByte();
        }

        public short LeerAtributoShort(IPropiedad propiedad)
        {
            return _reader.ReadInt16();
        }

        public string LeerAtributoString(IPropiedad propiedad)
        {
            return _reader.ReadString();
        }

        public uint LeerAtributoUInteger(IPropiedad propiedad)
        {
            return _reader.ReadUInt32();
        }

        public ulong LeerAtributoULong(IPropiedad propiedad)
        {
            return _reader.ReadUInt64();
        }

        public ushort LeerAtributoUShort(IPropiedad propiedad)
        {
            return _reader.ReadUInt16();
        }
        
    }
}
