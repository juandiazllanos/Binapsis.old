using System;
using Binapsis.Plataforma.Serializacion.Binario;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public class DeserializacionBinario : DeserializacionBase
    {
        public DeserializacionBinario(Type type)
            : base(type)
        {
        }

        public DeserializacionBinario(ConfiguracionBase objeto) 
            : base(objeto)
        {
        }

        protected override void Deserializar(Secuencia secuencia)
        {
            Deserializar(secuencia, new LectorBinario());
        }        
    }
}
