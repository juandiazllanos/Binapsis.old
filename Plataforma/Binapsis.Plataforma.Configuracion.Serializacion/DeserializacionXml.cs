using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Serializacion.Xml;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public class DeserializacionXml<T> : DeserializacionBase<T> where T : ObjetoBase
    {
        public DeserializacionXml() 
            : base()
        {
        }

        public DeserializacionXml(T objeto) 
            : base(objeto)
        {
        }

        protected override void Deserializar(Secuencia secuencia)
        {
            Deserializar(secuencia, new LectorXml(FabricaConfiguracion.Instancia));
        }        
    }
}
