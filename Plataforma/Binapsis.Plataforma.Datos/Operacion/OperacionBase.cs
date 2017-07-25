using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;

namespace Binapsis.Plataforma.Datos.Operacion
{
    abstract class OperacionBase 
    {
        public virtual void Ejecutar()
        {

        }

        public IContexto Contexto
        {
            get;
            set;
        }

        public MapeoCatalogo MapeoCatalogo
        {
            get;
            set;
        }
    }
}
