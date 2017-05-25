using System;

namespace Binapsis.Plataforma.Configuracion.Win
{
    public interface IContexto
    {
        IRepositorio Repositorio { get; }
        IElemento ElementoSeleccionado { get; }
        IElemento ElementoPropietario { get; }
        IElemento ElementoRoot { get; }
        Type Type { get; }
        void Refrescar();
    }
}
