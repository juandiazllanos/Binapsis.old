using System;
using Binapsis.Plataforma.Estructura;
using System.Xml;
using System.IO;
using System.Globalization;
using Binapsis.Plataforma.Serializacion.Impl;
using Binapsis.Plataforma.Cambios;

namespace Binapsis.Plataforma.Serializacion.Xml
{
    public class LectorXml : LectorBase
    {
        XmlReader _reader;
        int _iatr;
        bool _cerrado;
        string _ns;

        public LectorXml()
        {
            _ns = "https://binapsis.com/plataforma/serializacion";
        }
        
        protected override void EstablecerStream(Stream stream)
        {
            _reader = XmlReader.Create(stream);
            _reader.MoveToContent();
        }
        
        bool Siguiente()
        {
            bool leido;

            do            
                leido = _reader.Read() && _reader.NodeType == XmlNodeType.Element;              
            while (!leido && !_reader.EOF && _reader.NodeType != XmlNodeType.EndElement);
                        
            return leido;
        }

        public override bool Leer()
        {
            bool resul;

            // ubicar lector en el proximo elemento
            do
                resul = Siguiente();
            while (!_reader.EOF && !resul);

            // reiniciar lector en el elemento actual
            if (resul)
            {
                _iatr = 0;
                _cerrado = false;
            }
                
            return resul;
        }

        public override int LeerItems()
        {
            return int.Parse(_reader.GetAttribute("items", _ns));
        }

        public override int LeerId()
        {
            return int.Parse(_reader.GetAttribute("ref", _ns));
        }

        public override string LeerRuta()
        {
            return _reader.GetAttribute("ruta", _ns);
        }

        public override Cambio LeerCambio()
        {
            return (Cambio)Enum.Parse(typeof(Cambio), _reader.GetAttribute("cambio", _ns));
        }

        public override IPropiedad Leer(ITipo tipo)
        {
            IPropiedad propiedad = null;

            // leer atributo actual
            propiedad = LeerSiguienteAtributo(tipo);

            // retornar el atributo actual
            if (propiedad != null)
                return propiedad;
                        
            // leer siguiente referencia 
            propiedad = LeerSiguienteReferencia(tipo);

            // abrir la siguiente lectura
            if (propiedad == null)
                _cerrado = false;
            
            return propiedad;
        }

        private IPropiedad LeerSiguienteAtributo(ITipo tipo)
        {
            if (_iatr == -1) return null;

            IPropiedad propiedad = null;

            // leer atributo actual
            while (_iatr < _reader.AttributeCount && propiedad == null)
            {
                _reader.MoveToAttribute(_iatr);
                propiedad = tipo.ObtenerPropiedad(_reader.Name);
                _iatr++;
            }
            
            // estabecer valores de finalizacion 
            if (propiedad == null)
            {
                _reader.MoveToElement();
                // cerrar el elemento
                _cerrado = _reader.IsEmptyElement;
                // deshabiliar lectura de atributos en el elemento actual
                _iatr = -1;
            }
            
            return propiedad;
        }

        private IPropiedad LeerSiguienteReferencia(ITipo tipo)
        {
            if (_cerrado) return null;

            IPropiedad propiedad = null;
            
            // leer siguiente elemento y buscar la referencia
            while (propiedad == null && Siguiente())
                propiedad = tipo.ObtenerPropiedad(_reader.Name);
            
            // reiniciar indice de atributo actual para la siguiente referencia
            if (propiedad != null)
                _iatr = 0;

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
            return DateTime.ParseExact(_reader.Value, "o", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AssumeLocal);
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
