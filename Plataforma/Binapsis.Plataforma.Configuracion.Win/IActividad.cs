using Binapsis.Plataforma.Estructura.Impl;
using System;

namespace Binapsis.Plataforma.Configuracion.Win
{
    public interface IActividad
    {        
        void Iniciar();
        void Terminar();
        void Cancelar();

        IControlador Controlador { get; set; }
        ObjetoBase Estado { get; set; }
        Resultado Resultado { get; }
        Type Type { get; set; }
        
    }
}
