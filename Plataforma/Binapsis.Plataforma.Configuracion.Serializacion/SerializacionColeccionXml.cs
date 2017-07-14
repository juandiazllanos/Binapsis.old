using Binapsis.Plataforma.Serializacion.Xml;
using System.Collections;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public class SerializacionColeccionXml : SerializacionColeccion
    {
        public SerializacionColeccionXml(IList items) 
            : base(items)
        {
            Escritor = new EscritorXml();
        }
    }
}
