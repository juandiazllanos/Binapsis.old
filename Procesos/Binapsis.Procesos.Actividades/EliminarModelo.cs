using Binapsis.Consola.Definicion;
using Binapsis.Plataforma;
using Binapsis.Procesos.Trabajos;

namespace Binapsis.Procesos.Actividades
{
    public class EliminarModelo : Actividad
    {
        public EliminarModelo(ActividadInfo actividadInfo) 
            : base(actividadInfo)
        {
        }

        public override void EjecutarActividad()
        {
            EntidadBase modelo = Parametros["modelo"] as EntidadBase;
            EntidadRepositorio repositorio = new EntidadRepositorio();

            if (modelo != null)
                repositorio.Eliminar(modelo);
        }
    }
}
