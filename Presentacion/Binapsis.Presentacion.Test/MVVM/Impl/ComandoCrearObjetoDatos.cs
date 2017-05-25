using Binapsis.Presentacion.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Presentacion.Test.MVVM.Impl
{
    class ComandoCrearObjetoDatos : IComando
    {
        string _propiedad;

        public ComandoCrearObjetoDatos(string propiedad)
        {
            _propiedad = propiedad;
        }

        void IComando.Ejecutar(IObjetoDatos od)
        {
            od.CrearObjetoDatos(_propiedad);
        }
    }
}
