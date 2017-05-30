using System;

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
