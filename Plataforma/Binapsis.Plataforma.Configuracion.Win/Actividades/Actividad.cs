using System;

namespace Binapsis.Plataforma.Configuracion.Win.Actividades
{
    internal abstract class Actividad : IActividad 
    {
        public abstract void Iniciar();

        public void Terminar()
        {
            Resultado = Resultado.OK;
            Controlador?.Siguiente();
        }

        public virtual void Cancelar()
        {
            Resultado = Resultado.Cancel;
            Controlador?.Siguiente();
        }

        public ConfiguracionBase Estado
        {
            get;
            set;
        }

        public IControlador Controlador { get; set; }
        public Resultado Resultado { get; private set; }
        public Type Type { get; set; }
        
    }
}
