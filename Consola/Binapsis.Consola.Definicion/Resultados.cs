using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Consola.Definicion
{
    public class Resultados : ColeccionBase<ResultadoInfo>
    {
        TrabajoInfo _trabajoInfo;

        public Resultados(TrabajoInfo trabajoInfo)
        {
            _trabajoInfo = trabajoInfo;
        }

        protected override ResultadoInfo Instanciar(string nombre)
        {
            return new ResultadoInfo(_trabajoInfo) { Nombre = nombre };
        }
    }
}
