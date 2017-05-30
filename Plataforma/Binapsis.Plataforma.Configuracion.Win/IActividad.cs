using System;

namespace Binapsis.Plataforma.Configuracion.Win
{
    public interface IActividad
    {        
        void Iniciar();
        void Terminar();
        void Cancelar();

        IControlador Controlador { get; set; }
        ConfiguracionBase Estado { get; set; }
        Resultado Resultado { get; }
        Type Type { get; set; }
        
    }
}
