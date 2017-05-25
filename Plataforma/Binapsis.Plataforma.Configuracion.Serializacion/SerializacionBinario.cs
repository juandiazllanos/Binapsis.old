using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Serializacion.Binario;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public class SerializacionBinario<T> : SerializacionBase<T> where T : ObjetoBase
    {
        public SerializacionBinario()
            : base()
        {
        }

        public SerializacionBinario(T objeto) 
            : base(objeto)
        {
        }

        protected override void Serializar(Secuencia secuencia)
        {
            Serializar(secuencia, new EscritorBinario());
        }
    }
}
