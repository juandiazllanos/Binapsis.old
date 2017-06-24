using System;
using Binapsis.Plataforma.Estructura;
using System.IO;
using Binapsis.Plataforma.Serializacion.Impl;
using Binapsis.Plataforma.Cambios;

namespace Binapsis.Plataforma.Serializacion.Binario
{
    public class LectorBinario : LectorBase
    {
        BinaryReader _reader;
        int _id;
        
        protected override void EstablecerStream(Stream stream)
        {
            if (_reader == null)
                EstablecerReader(new BinaryReader(stream));
        }

        void EstablecerReader(BinaryReader reader)
        {
            _reader = reader;
        }
        
        public override IPropiedad Leer(ITipo tipo)
        {
            if (_reader.BaseStream.Position >= _reader.BaseStream.Length) return null;

            ushort i = _reader.ReadUInt16();
            IPropiedad propiedad = null;

            if (i >= 0 && i < tipo.Propiedades.Count)
                propiedad = tipo.ObtenerPropiedad(i);
                              
            return propiedad;
        }


        public override bool Leer()
        {
            return _reader.BaseStream.Position < _reader.BaseStream.Length;
        }

        public override int LeerItems()
        {
            return _reader.ReadInt32();
        }

        public override int LeerId()
        {
            return _id = _reader.ReadInt32(); 
        }

        public override string LeerRuta()
        {
            return _reader.ReadString();
        }

        public override Cambio LeerCambio()
        {
            return (Cambio)_reader.ReadByte();
        }

        public override bool LeerBoolean()
        {
            return _reader.ReadBoolean();
        }

        public override byte LeerByte()
        {
            return _reader.ReadByte();
        }

        public override char LeerChar()
        {
            return _reader.ReadChar();
        }

        public override DateTime LeerDateTime()
        {
            return new DateTime(_reader.ReadInt64());
        }

        public override decimal LeerDecimal()
        {
            return _reader.ReadDecimal();
        }

        public override double LeerDouble()
        {
            return _reader.ReadDouble();
        }

        public override float LeerFloat()
        {
            return _reader.ReadSingle(); 
        }
        
        public override int LeerInteger()
        {
            return _reader.ReadInt32();
        }

        public override long LeerLong()
        {
            return _reader.ReadInt64();
        }

        public override object LeerObject()
        {
            return null;
        }

        public override sbyte LeerSByte()
        {
            return _reader.ReadSByte();
        }

        public override short LeerShort()
        {
            return _reader.ReadInt16();
        }

        public override string LeerString()
        {
            return _reader.ReadString();
        }

        public override uint LeerUInteger()
        {
            return _reader.ReadUInt32();
        }

        public override ulong LeerULong()
        {
            return _reader.ReadUInt64();
        }

        public override ushort LeerUShort()
        {
            return _reader.ReadUInt16();
        }
        
    }
}
