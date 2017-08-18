using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;
using System;

namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    public class AccionEventArgs : EventArgs
    {
        public Accion Accion
        {
            get;
            internal set;
        }

        public Elemento Elemento
        {
            get;
            internal set;
        }

        public Type Type
        {
            get;
            internal set;
        }

    }
}
