using Binapsis.Plataforma.Serializacion.Xml;
using System;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public class SerializacionXml: SerializacionBase
    {
        public SerializacionXml(Type type)
            : base(type)
        {
        }

        public SerializacionXml(ConfiguracionBase objeto) 
            : base(objeto)
        {
        }

        protected override void Serializar(Secuencia secuencia)
        {
            Serializar(secuencia, new EscritorXml());
        }
    }
}
