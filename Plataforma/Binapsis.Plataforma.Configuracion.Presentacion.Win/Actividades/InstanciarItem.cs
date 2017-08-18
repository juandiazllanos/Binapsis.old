using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Actividades
{
    class InstanciarItem : Actividad
    {
        public override void Iniciar()
        {
            ConfiguracionBase instancia = Parametros["instancia"] as ConfiguracionBase;
            string propiedad = Parametros["propiedad"] as string;

            if (instancia != null && propiedad != null)
            {
                Parametros["item"] = (instancia as IObjetoDatos).CrearObjetoDatos(propiedad) as ConfiguracionBase;
                Terminar();
            }
            else
                Cancelar();
        }
    }
}
