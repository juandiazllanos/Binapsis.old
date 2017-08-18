using System;

namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    public interface IContexto
    {   
        Repositorio Repositorio { get; }

        IFabrica ObtenerFabrica(string nombre);
        
    }
}
