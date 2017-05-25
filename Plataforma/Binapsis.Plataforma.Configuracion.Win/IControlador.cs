using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binapsis.Plataforma.Configuracion.Win
{
    public interface IControlador
    {
        void Siguiente();
        void Ejecutar();

        Accion Accion { get; }
        IContexto Contexto { get; }
        Type Type { get; }
    }
}
