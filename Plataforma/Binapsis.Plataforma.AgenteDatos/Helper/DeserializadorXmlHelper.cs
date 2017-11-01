using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Serializacion;
using Binapsis.Plataforma.Serializacion.Impl;
using Binapsis.Plataforma.Serializacion.Xml;

namespace Binapsis.Plataforma.AgenteDatos.Helper
{
    static class DeserializadorXmlHelper
    {
        public static IColeccion DeserializarColeccion(IFabrica fabrica, ITipo tipo, string data)
        {
            ISecuencia secuencia = new Secuencia(data);
            ILector lector = new LectorXml();
            Coleccion coleccion = new Coleccion();
            Deserializador helper = new DeserializadorObjetoDatos(secuencia, lector, fabrica);

            helper.Deserializar(tipo, coleccion);

            return coleccion;
        }

        public static IObjetoDatos DeserializarObjetoDatos(IFabrica fabrica, ITipo tipo, string data)
        {
            ISecuencia secuencia = new Secuencia(data);
            ILector lector = new LectorXml();
            IObjetoDatos od = fabrica.Crear(tipo);
            Deserializador helper = new DeserializadorObjetoDatos(secuencia, lector);

            helper.Deserializar(od);

            return od;
        }

    }
}
