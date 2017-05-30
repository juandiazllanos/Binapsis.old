using Binapsis.Plataforma.Serializacion.Xml;
using System;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public class DeserializacionXml : DeserializacionBase 
    {
        public DeserializacionXml(Type type) 
            : base(type)
        {
        }

        public DeserializacionXml(ConfiguracionBase objeto) 
            : base(objeto)
        {
        }

        protected override void Deserializar(Secuencia secuencia)
        {
            Deserializar(secuencia, new LectorXml(Fabrica.Instancia));
        }        
    }
}
