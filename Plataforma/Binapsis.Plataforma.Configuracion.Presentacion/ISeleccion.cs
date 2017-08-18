using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    public interface ISeleccion
    {
        string Categoria { get; }
        Clave Clave { get; }
    }
}
