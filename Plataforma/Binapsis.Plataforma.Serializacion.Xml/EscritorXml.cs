using System;
using Binapsis.Plataforma.Estructura;
using System.Xml;
using System.IO;
using System.Globalization;
using Binapsis.Plataforma.Serializacion.Impl;

namespace Binapsis.Plataforma.Serializacion.Xml
{
    public class EscritorXml : EscritorBase
    {
        XmlWriter _writer;

        public EscritorXml()
        {

        }

        protected EscritorXml(XmlWriter writer)
        {
            _writer = writer;
        }
        
        protected override void EstablecerStream(Stream stream)
        {
            base.EstablecerStream(stream);

            if (_writer == null)
                _writer = XmlWriter.Create(stream);
        }

        public override void Escribir(INodoObjeto objeto)
        {
            Escribir(objeto, objeto.Tipo.Nombre);            
        }

        public void Escribir(INodoObjeto objeto, string nombreElemento)
        {
            _writer.WriteStartElement(nombreElemento);
            base.Escribir(objeto);
            _writer.WriteEndElement();
            _writer.Flush();
        }

        public void Escribir(int id, string nombreElemento)
        {
            _writer.WriteStartElement(nombreElemento);
            EscribirId(id);
            _writer.WriteEndElement();
            _writer.Flush();
        }

        public override void EscribirId(int id)
        {
            EscribirAtributoXml("id", id.ToString());
        }
        
        private void EscribirAtributoXml(IPropiedad propiedad, string valor)
        {
            EscribirAtributoXml(propiedad.Nombre, valor);
        }

        private void EscribirAtributoXml(string nombre, string valor)
        {
            _writer.WriteAttributeString(nombre, valor);
        }

        public override void EscribirBoolean(IPropiedad propiedad, bool valor)
        {
            EscribirAtributoXml(propiedad, valor.ToString());
        }

        public override void EscribirByte(IPropiedad propiedad, byte valor)
        {
            EscribirAtributoXml(propiedad, valor.ToString());
        }

        public override void EscribirChar(IPropiedad propiedad, char valor)
        {
            EscribirAtributoXml(propiedad, Convert.ToUInt16(valor).ToString());
        }

        public override void EscribirDateTime(IPropiedad propiedad, DateTime valor)
        {
            EscribirAtributoXml(propiedad, valor.ToString("s", DateTimeFormatInfo.InvariantInfo));
        }

        public override void EscribirDecimal(IPropiedad propiedad, decimal valor)
        {
            EscribirAtributoXml(propiedad, valor.ToString());
        }

        public override void EscribirDouble(IPropiedad propiedad, double valor)
        {
            EscribirAtributoXml(propiedad, valor.ToString("r"));
        }

        public override void EscribirFloat(IPropiedad propiedad, float valor)
        {
            EscribirAtributoXml(propiedad, valor.ToString("r"));
        }
        
        public override void EscribirInteger(IPropiedad propiedad, int valor)
        {
            EscribirAtributoXml(propiedad, valor.ToString());
        }

        public override void EscribirLong(IPropiedad propiedad, long valor)
        {
            EscribirAtributoXml(propiedad, valor.ToString());
        }

        public override void EscribirObject(IPropiedad propiedad, object valor)
        {
            EscribirAtributoXml(propiedad, valor.ToString());
        }

        public override void EscribirSByte(IPropiedad propiedad, sbyte valor)
        {
            EscribirAtributoXml(propiedad, valor.ToString());
        }

        public override void EscribirShort(IPropiedad propiedad, short valor)
        {
            EscribirAtributoXml(propiedad, valor.ToString());
        }

        public override void EscribirString(IPropiedad propiedad, string valor)
        {
            EscribirAtributoXml(propiedad, valor.ToString());
        }

        public override void EscribirUInteger(IPropiedad propiedad, uint valor)
        {
            EscribirAtributoXml(propiedad, valor.ToString());
        }

        public override void EscribirULong(IPropiedad propiedad, ulong valor)
        {
            EscribirAtributoXml(propiedad, valor.ToString());
        }

        public override void EscribirUShort(IPropiedad propiedad, ushort valor)
        {
            EscribirAtributoXml(propiedad, valor.ToString());
        }

        public override void EscribirObjetoDatos(IPropiedad propiedad, INodoObjeto valor)
        {
            Escribir(valor, propiedad.Nombre);            
        }
    }
}
