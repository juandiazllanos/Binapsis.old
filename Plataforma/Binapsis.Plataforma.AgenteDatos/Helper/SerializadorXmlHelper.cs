using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion;
using Binapsis.Plataforma.Serializacion.Impl;
using Binapsis.Plataforma.Serializacion.Xml;

using System.Collections.Generic;

namespace Binapsis.Plataforma.AgenteDatos.Helper
{
    static class SerializadorXmlHelper
    {
        public static byte[] Serializar(IObjetoDatos od)
        {
            return SerializarObjetoDatos(od);
        }

        public static byte[] Serializar(IColeccion col)
        {
            return SerializarObjetoDatos(col);
        }

        public static byte[] Serializar(IDiagramaDatos dd)
        {
            return SerializarDiagramaDatos(dd);
        }

        public static byte[] Serializar(IList<IDiagramaDatos> items)
        {
            return SerializarDiagramaDatos(items);
        }

        private static byte[] SerializarObjetoDatos(object obj)
        {
            Secuencia secuencia = new Secuencia();
            IEscritor escritor = new EscritorXml();
            Serializador helper = new SerializadorObjetoDatos(secuencia, escritor);

            helper.Serializar(obj);

            return secuencia.Contenido;
        }

        private static byte[] SerializarDiagramaDatos(object obj)
        {
            Secuencia secuencia = new Secuencia();
            IEscritor escritor = new EscritorXml();
            Serializador helper = new SerializadorDiagramaDatos(secuencia, escritor);

            helper.Serializar(obj);

            return secuencia.Contenido;
        }
    }
}
