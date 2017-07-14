using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Datos.Operacion
{
    abstract class OperacionBase : ComandoBase
    {
        public IContexto Contexto
        {
            get;
            set;
        }

        public IObjetoDatos ObjetoDatos
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
