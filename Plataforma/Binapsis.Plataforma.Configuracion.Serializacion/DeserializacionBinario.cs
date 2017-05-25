using System;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Serializacion.Binario;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public class DeserializacionBinario<T> : DeserializacionBase<T> where T : ObjetoBase
    {
        public DeserializacionBinario()
            : base()
        {
        }

        public DeserializacionBinario(T objeto) 
            : base(objeto)
        {
        }

        protected override void Deserializar(Secuencia secuencia)
        {
            Deserializar(secuencia, new LectorBinario(FabricaConfiguracion.Instancia));
        }        
    }
}
