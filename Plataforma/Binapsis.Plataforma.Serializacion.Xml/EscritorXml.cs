using System;
using Binapsis.Plataforma.Estructura;
using System.Xml;
using System.IO;
using System.Globalization;
using Binapsis.Plataforma.Serializacion.Impl;
using Binapsis.Plataforma.Cambios;

namespace Binapsis.Plataforma.Serializacion.Xml
{
    public class EscritorXml : EscritorBase
    {
        XmlWriter _writer;
        string _ns;

        public EscritorXml()
        {
            _ns = "https://binapsis.com/plataforma/serializacion";
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
        
        public override void EscribirColeccion(int items)
        {
            EscribirElemento("Coleccion");
            EscribirItems(items);
        }

        public override void EscribirColeccionCierre()
        {
            EscribirElementoCierre();
        }

        public override void EscribirDiagramaDatos()
        {
            EscribirElemento("DiagramaDatos");
        }

        public override void EscribirDiagramaDatosCierre()
        {
            EscribirElementoCierre();
        }

        public override void EscribirObjetoDatos(ITipo tipo, int id, string ruta, Cambio cambio)
        {
            EscribirElemento("ResumenCambios", id);
            EscribirAtributoXml(_ns, "ruta", ruta);
            EscribirAtributoXml(_ns, "cambio", cambio.ToString());
        }

        public override void EscribirObjetoDatos(IPropiedad propiedad, int id, string ruta, Cambio cambio)
        {
            EscribirElemento(propiedad.Nombre, id);
            EscribirAtributoXml(_ns, "ruta", ruta);
            EscribirAtributoXml(_ns, "cambio", cambio.ToString());
        }
        
        public override void EscribirObjetoDatos(ITipo tipo, int id)
        {
            EscribirElemento(tipo.Nombre, id);            
        }
        
        public override void EscribirObjetoDatos(IPropiedad propiedad, int id)
        {
            EscribirElemento(propiedad.Nombre, id);            
        }

        public override void EscribirObjetoDatosCierre()
        {
            EscribirElementoCierre();
        }

        public void EscribirElemento(string nombreElemento, int id)
        {
            EscribirElemento(nombreElemento);
            EscribirId(id);
        }

        public void EscribirElemento(string nombreElemento)
        {
            _writer.WriteStartElement(nombreElemento);

            //escribir xml namespace
            if (_writer.LookupPrefix(_ns) == null)
                EscribirNamespace();
        }

        public void EscribirElementoCierre()
        {
            _writer.WriteEndElement();
            _writer.Flush();
        }

        public void EscribirNamespace()
        {
            _writer.WriteAttributeString("xmlns", "x", null, _ns);
        }

        private void EscribirItems(int items)
        {
            EscribirAtributoXml(_ns, "items", items.ToString());
        }

        private void EscribirId(int id)
        {
            EscribirAtributoXml(_ns, "ref", id.ToString());
        }

        private void EscribirAtributoXml(IPropiedad propiedad, string valor)
        {
            EscribirAtributoXml(propiedad.Nombre, valor);
        }

        private void EscribirAtributoXml(string nombre, string valor)
        {
            _writer.WriteAttributeString(nombre, valor);
        }

        private void EscribirAtributoXml(string ns, string nombre, string valor)
        {
            _writer.WriteAttributeString(nombre, ns, valor);
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
            EscribirAtributoXml(propiedad, valor.ToString("o", DateTimeFormatInfo.InvariantInfo));
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

    }
}
