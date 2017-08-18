using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;
using Binapsis.Plataforma.Estructura;
using System.Linq;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Actividades
{
    class EliminarItem : Actividad
    {
        public override void Iniciar()
        {
            ConfiguracionBase instancia = Parametros["instancia"] as ConfiguracionBase;
            ConfiguracionBase item = Parametros["item"] as ConfiguracionBase;
            string propiedad = Parametros["propiedad"] as string;
            
            if (instancia != null && propiedad != null && item != null)                
            {
                (instancia as IObjetoDatos).RemoverObjetoDatos(propiedad, item);
                Terminar();
            }
            else
                Cancelar();
        }
    }
 }
