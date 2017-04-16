using System;
using Binapsis.Plataforma.Estructura;
using System.IO;
using Binapsis.Plataforma.Serializacion.Impl;

namespace Binapsis.Plataforma.Serializacion.Binario
{
    public class LectorBinario : LectorBase
    {
        BinaryReader _reader;
        int _id;

        public LectorBinario()
            : base()
        {
        }

        protected LectorBinario(LectorBase lector, BinaryReader reader) 
            : base(lector)
        {
            EstablecerReader(reader);
        }

        protected override void EstablecerStream(Stream stream)
        {
            if (_reader == null)
                EstablecerReader(new BinaryReader(stream));
        }

        void EstablecerReader(BinaryReader reader)
        {
            _reader = reader;
            _id = _reader.ReadInt32(); // leer id (una sola vez)
        }

        public override void Leer(IObjetoDatos od)
        {
            if (od == null) return;
            
            System.Diagnostics.Debug.WriteLine(string.Format("id={0}", _id));

            // leer objeto
            base.Leer(od);
        }

        public override IPropiedad Leer()
        {
            if (_reader.BaseStream.Position >= _reader.BaseStream.Length) return null;

            ushort i = _reader.ReadUInt16();
            IPropiedad propiedad = null;

            if (i >= 0 && i < Tipo.Propiedades.Count)
                propiedad = Tipo.ObtenerPropiedad(i);
            
            System.Diagnostics.Debug.WriteLine(string.Format("{0}.{1}.[{2}]", Tipo.Nombre, _id, propiedad?.Nombre));
                                        
            return propiedad;
        }


        public override int LeerId()
        {
            return _id;
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

        protected override ILector Crear()
        {
            return new LectorBinario(this, _reader);
        }
    }
}
