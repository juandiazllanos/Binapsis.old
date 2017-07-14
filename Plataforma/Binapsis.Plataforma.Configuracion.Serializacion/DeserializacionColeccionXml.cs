using System;
using Binapsis.Plataforma.Serializacion.Xml;
using System.Collections;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public class DeserializacionColeccionXml : DeserializacionColeccion
    {
        public DeserializacionColeccionXml(Type type) 
            : base(type)
        {
            Lector = new LectorXml();
        }

        public DeserializacionColeccionXml(Type type, IList items) 
            : base(type, items)
        {
            Lector = new LectorXml();
        }
    }
}
