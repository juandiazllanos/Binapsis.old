using System;
using System.IO;
using Binapsis.Plataforma.Estructura;
using System.Xml;

namespace Binapsis.Plataforma.Serializacion.Xml
{
    public class LectorXml : ILector
    {
        XmlReader _reader;
        Stream _stream;

        public void Abrir(Stream stream)
        {
            // inicializar lector xml
            _reader = XmlReader.Create(stream);
            _stream = stream;

            // ubicarse en el elemento raíz
            Leer();
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
        
        private bool Leer()
        {
            bool leido;

            do
            {
                leido = _reader.Read();
            }
            while (!_reader.EOF && _reader.NodeType != XmlNodeType.Element);

            return leido;
        }

        public IPropiedad Leer(ITipo contexto)
        {
            IPropiedad propiedad = null;

            if (_reader.MoveToNextAttribute())
                propiedad = contexto[_reader.Name];

            return propiedad;
        }

        public bool LeerAtributoBoolean(IPropiedad propiedad)
        {
            return bool.Parse(_reader.Value);
        }

        public byte LeerAtributoByte(IPropiedad propiedad)
        {
            return byte.Parse(_reader.Value);
        }

        public char LeerAtributoChar(IPropiedad propiedad)
        {
            return Convert.ToChar(ushort.Parse(_reader.Value));
        }

        public DateTime LeerAtributoDateTime(IPropiedad propiedad)
        {
            return new DateTime(long.Parse(_reader.Value));
        }

        public decimal LeerAtributoDecimal(IPropiedad propiedad)
        {
            return decimal.Parse(_reader.Value);
        }

        public double LeerAtributoDouble(IPropiedad propiedad)
        {
            return double.Parse(_reader.Value);
        }

        public float LeerAtributoFloat(IPropiedad propiedad)
        {
            return float.Parse(_reader.Value);
        }

        public int LeerAtributoInteger(IPropiedad propiedad)
        {
            return int.Parse(_reader.Value);
        }

        public long LeerAtributoLong(IPropiedad propiedad)
        {
            return long.Parse(_reader.Value);
        }

        public object LeerAtributoObject(IPropiedad propiedad)
        {
            return null;
        }

        public sbyte LeerAtributoSByte(IPropiedad propiedad)
        {
            return sbyte.Parse(_reader.Value);
        }

        public short LeerAtributoShort(IPropiedad propiedad)
        {
            return short.Parse(_reader.Value);
        }

        public string LeerAtributoString(IPropiedad propiedad)
        {
            return _reader.Value;
        }

        public uint LeerAtributoUInteger(IPropiedad propiedad)
        {
            return uint.Parse(_reader.Value);
        }

        public ulong LeerAtributoULong(IPropiedad propiedad)
        {
            return ulong.Parse(_reader.Value);
        }

        public ushort LeerAtributoUShort(IPropiedad propiedad)
        {
            return ushort.Parse(_reader.Value);
        }
        
        public byte LeerMetodo()
        {
            byte metodo = 0;

            if (Leer() && _reader.MoveToAttribute("_met"))
                metodo = byte.Parse(_reader.Value);
            
            return metodo;
        }

        public int LeerMetodoIdentidad()
        {
            int valor = 0;
            if (_reader.MoveToAttribute("_refid"))
                valor = int.Parse(_reader.Value);
            return valor;
        }

        public int LeerMetodoLongitud()
        {
            int valor = 0;
            if (_reader.MoveToAttribute("_long"))
                valor = int.Parse(_reader.Value);
            return valor;
        }

        public int LeerMetodoPropietario()
        {
            int valor = 0;
            if (_reader.MoveToAttribute("_od"))
                valor = int.Parse(_reader.Value);
            return valor;
        }

        public int LeerMetodoPropiedad()
        {
            int valor = 0;
            if (_reader.MoveToAttribute("_prop"))
                valor = int.Parse(_reader.Value);
            return valor;
        }

        public string LeerMetodoUri()
        {
            string valor = string.Empty;
            if (_reader.MoveToAttribute("_uri"))
                valor = _reader.Value;
            return valor;
        }

        public string LeerMetodoTipo()
        {
            string valor = string.Empty;
            if (_reader.MoveToAttribute("_nombre"))
                valor = _reader.Value;
            return valor;
        }
    }
}
