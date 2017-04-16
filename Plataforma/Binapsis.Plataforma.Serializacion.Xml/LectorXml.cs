using System;
using Binapsis.Plataforma.Estructura;
using System.Xml;
using System.IO;
using System.Globalization;
using Binapsis.Plataforma.Serializacion.Impl;

namespace Binapsis.Plataforma.Serializacion.Xml
{
    public class LectorXml : LectorBase
    {
        XmlReader _reader;
        string _elem;
        int _iatr;        
        bool _isEmpty;
        bool _finalizado;
        
        public LectorXml()
            : base()
        {

        }

        public LectorXml(LectorBase lector, XmlReader reader)
            : base(lector)
        {
            _reader = reader;
            _reader.MoveToElement();
            _elem = _reader.Name;
            _isEmpty = _reader.IsEmptyElement;
        }

        protected override void EstablecerStream(Stream stream)
        {
            _reader = XmlReader.Create(stream);
            _reader.MoveToContent();
            _elem = _reader.Name;
            _isEmpty = _reader.IsEmptyElement;
        }

        protected override ILector Crear()
        {
            return new LectorXml(this, _reader);
        }

        bool Siguiente()
        {
            if (_finalizado || _isEmpty) return false;

            bool leido;

            do
            {
                leido = _reader.Read();
                _finalizado = (_reader.NodeType == XmlNodeType.EndElement);       
            }
            while ( leido && !_finalizado && 
                    _reader.NodeType != XmlNodeType.Element && 
                    !_reader.EOF);
                        
            return leido && !_finalizado;
        }
               
        public override int LeerId()
        {
            return int.Parse(_reader.GetAttribute("id"));
        }

        public override IPropiedad Leer()
        {
            if (_finalizado) return null;

            IPropiedad propiedad = null;

            while (_iatr < _reader.AttributeCount && propiedad == null)
            {
                _reader.MoveToAttribute(_iatr);
                propiedad = Tipo.ObtenerPropiedad(_reader.Name);
                _iatr++;
            }
            
            while (propiedad == null && Siguiente())
            {
                propiedad = Tipo.ObtenerPropiedad(_reader.Name);
            }
            
            return propiedad;
        }

        public override bool LeerBoolean()
        {
            return bool.Parse(_reader.Value);
        }

        public override byte LeerByte()
        {
            return byte.Parse(_reader.Value);
        }

        public override char LeerChar()
        {
            return (char)uint.Parse(_reader.Value);
        }

        public override DateTime LeerDateTime()
        {
            return DateTime.ParseExact(_reader.Value, "s", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AssumeLocal);
        }

        public override decimal LeerDecimal()
        {
            return decimal.Parse(_reader.Value);
        }

        public override double LeerDouble()
        {
            return double.Parse(_reader.Value);
        }

        public override float LeerFloat()
        {
            return float.Parse(_reader.Value);
        }

        public override int LeerInteger()
        {
            return int.Parse(_reader.Value);
        }

        public override long LeerLong()
        {
            return long.Parse(_reader.Value);
        }

        public override object LeerObject()
        {
            return null;
        }

        public override sbyte LeerSByte()
        {
            return sbyte.Parse(_reader.Value);
        }

        public override short LeerShort()
        {
            return short.Parse(_reader.Value);
        }

        public override string LeerString()
        {
            return _reader.Value;
        }

        public override uint LeerUInteger()
        {
            return uint.Parse(_reader.Value);
        }

        public override ulong LeerULong()
        {
            return ulong.Parse(_reader.Value);
        }

        public override ushort LeerUShort()
        {
            return ushort.Parse(_reader.Value);
        }
    }
}
