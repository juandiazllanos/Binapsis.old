using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Datos.Builder
{
    abstract class BuilderComando
    {
        public BuilderComando(Comando comando)
        {
            Comando = comando;
        }

        public Comando Comando
        {
            get;
        }

        public MapeoTabla MapeoTabla
        {
            get;
            set;
        }

        public virtual void Construir()
        {
            // validar mapeo
            if (MapeoTabla == null) return;
            // construir sentecia
            ConstruirSentencia();
            // construir parametros
            ConstruirParametros();
        }

        protected abstract void ConstruirSentencia();

        protected abstract void ConstruirParametros();
        
    }
}
