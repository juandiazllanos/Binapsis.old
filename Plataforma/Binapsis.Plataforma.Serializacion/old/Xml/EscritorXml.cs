using Binapsis.Plataforma.Estructura;
using System;
using System.IO;
using System.Xml;

namespace Binapsis.Plataforma.Serializacion.Xml
{
    public class EscritorXml : IEscritor
    {
        XmlWriter _writer;
        Stream _stream;

        public void Abrir(Stream stream)
        {
            _writer = XmlWriter.Create(stream, new XmlWriterSettings() { WriteEndDocumentOnClose = true });
            _stream = stream;
            _writer.WriteStartElement("root");
        }

        public void Cerrar()
        {
            if (_writer != null)
            {
                _writer.Flush();
                _writer.Dispose();
                _writer = null;
            }

            if (_stream != null)
            {
                _stream.Dispose();
                _writer = null;
            }
        }

        public void EscribirAtributoBoolean(IPropiedad propiedad, bool valor)
        {
            _writer.WriteAttributeString(propiedad.Nombre, valor.ToString());
        }

        public void EscribirAtributoByte(IPropiedad propiedad, byte valor)
        {
            _writer.WriteAttributeString(propiedad.Nombre, valor.ToString());
        }

        public void EscribirAtributoChar(IPropiedad propiedad, char valor)
        {
            _writer.WriteAttributeString(propiedad.Nombre, Convert.ToUInt16(valor).ToString());
        }

        public void EscribirAtributoDateTime(IPropiedad propiedad, DateTime valor)
        {
            _writer.WriteAttributeString(propiedad.Nombre, valor.Ticks.ToString());
        }

        public void EscribirAtributoDecimal(IPropiedad propiedad, decimal valor)
        {
            _writer.WriteAttributeString(propiedad.Nombre, valor.ToString());
        }

        public void EscribirAtributoDouble(IPropiedad propiedad, double valor)
        {
            _writer.WriteAttributeString(propiedad.Nombre, valor.ToString("r"));
        }

        public void EscribirAtributoFloat(IPropiedad propiedad, float valor)
        {
            _writer.WriteAttributeString(propiedad.Nombre, valor.ToString("r"));
        }

        public void EscribirAtributoInteger(IPropiedad propiedad, int valor)
        {
            _writer.WriteAttributeString(propiedad.Nombre, valor.ToString());
        }

        public void EscribirAtributoLong(IPropiedad propiedad, long valor)
        {
            _writer.WriteAttributeString(propiedad.Nombre, valor.ToString());
        }

        public void EscribirAtributoObject(IPropiedad propiedad, object valor)
        {

        }

        public void EscribirAtributoSByte(IPropiedad propiedad, sbyte valor)
        {
            _writer.WriteAttributeString(propiedad.Nombre, valor.ToString());
        }

        public void EscribirAtributoShort(IPropiedad propiedad, short valor)
        {
            _writer.WriteAttributeString(propiedad.Nombre, valor.ToString());
        }

        public void EscribirAtributoString(IPropiedad propiedad, string valor)
        {
            _writer.WriteAttributeString(propiedad.Nombre, valor.ToString());
        }

        public void EscribirAtributoUInteger(IPropiedad propiedad, uint valor)
        {
            _writer.WriteAttributeString(propiedad.Nombre, valor.ToString());
        }

        public void EscribirAtributoULong(IPropiedad propiedad, ulong valor)
        {
            _writer.WriteAttributeString(propiedad.Nombre, valor.ToString());
        }

        public void EscribirAtributoUShort(IPropiedad propiedad, ushort valor)
        {
            _writer.WriteAttributeString(propiedad.Nombre, valor.ToString());
        }

        public void EscribirMetodo(byte metodo)
        {
            _writer.WriteStartElement("ref");
            _writer.WriteAttributeString("_met", metodo.ToString());
        }

        public void EscribirMetodoIdentidad(int refid)
        {
            _writer.WriteAttributeString("_refid", refid.ToString());
        }

        public void EscribirMetodoLongitud(int longitud)
        {
            _writer.WriteAttributeString("_long", longitud.ToString());
        }

        public void EscribirMetodoPropietario(int propietario)
        {
            _writer.WriteAttributeString("_od", propietario.ToString());
        }

        public void EscribirMetodoPropiedad(int propiedad)
        {
            _writer.WriteAttributeString("_prop", propiedad.ToString());
        }

        public void EscribirMetodoUri(string uri)
        {
            _writer.WriteAttributeString("_uri", uri);
        }

        public void EscribirMetodoTipo(string nombre)
        {
            _writer.WriteAttributeString("_nombre", nombre);
        }

        public void EscribirMetodoCierre()
        {
            _writer.WriteEndElement();
        }

    }
}