using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Serializacion.Xml;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public class SerializacionXml<T> : SerializacionBase<T> where T : ObjetoBase
    {
        public SerializacionXml()
            : base()
        {
        }

        public SerializacionXml(T objeto) 
            : base(objeto)
        {
        }

        protected override void Serializar(Secuencia secuencia)
        {
            Serializar(secuencia, new EscritorXml());
        }
    }
}
