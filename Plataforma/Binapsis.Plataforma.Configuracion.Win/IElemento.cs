using System;

namespace Binapsis.Plataforma.Configuracion.Win
{
    public interface IElemento
    {
        string Alias { get; }
        IElemento[] Items { get; }
        string Nombre { get; }
        IElemento Propietario { get; }
        IRepositorio Repositorio { get; }
        IElemento Root { get; }
        string Valor { get; } 
        Type Type { get; }
        Type TypeItem { get; }

        void Actualizar();
    }
}
