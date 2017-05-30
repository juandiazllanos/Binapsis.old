using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Configuracion.Win.Actividades
{
    class InstanciarItem : Actividad
    {
        public override void Iniciar()
        {
            ObjetoBase propietario = Estado;
            
            if (propietario == null)
            {
                Cancelar();
                return;
            }
                
            if (propietario.GetType() == typeof(Tipo))
                Estado = ((Tipo)propietario).CrearPropiedad();

            else if (propietario.GetType() == typeof(Tabla))
                Estado = ((Tabla)propietario).CrearColumna();

            Terminar();
        }
    }
}
