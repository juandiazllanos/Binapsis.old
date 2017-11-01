using System;
using Binapsis.Plataforma;
using Binapsis.Consola.Definicion;
using Binapsis.Procesos.Trabajos;

namespace Binapsis.Procesos.Actividades
{
    public class InstanciarModelo : Actividad
    {
        public InstanciarModelo(ActividadInfo actividadInfo) 
            : base(actividadInfo)
        {
        }

        public override void EjecutarActividad()
        {
            Type type = Parametros["type"] as Type;
            DataFactory fabrica = HelperContext.DataFactory;
            EntidadBase modelo = type != null ? fabrica?.Crear(type) : null;
                        
            Parametros["modelo"] = modelo;
        }
        
    }
}
