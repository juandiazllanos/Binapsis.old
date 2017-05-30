using Binapsis.Plataforma.Serializacion.Binario;
using System;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public class SerializacionBinario : SerializacionBase
    {
        public SerializacionBinario(Type type)
            : base(type)
        {
        }

        public SerializacionBinario(ConfiguracionBase objeto) 
            : base(objeto)
        {
        }

        protected override void Serializar(Secuencia secuencia)
        {
            Serializar(secuencia, new EscritorBinario());
        }
    }
}
