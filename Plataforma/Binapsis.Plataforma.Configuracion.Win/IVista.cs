﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binapsis.Plataforma.Configuracion.Win
{
    interface IVista
    {
        void Mostrar();
        Resultado Resultado { get; }
    }
}
