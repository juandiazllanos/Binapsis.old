using Binapsis.Consola.Definicion;
using Binapsis.Plataforma;
using Binapsis.Plataforma.AgenteDatos;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using Binapsis.Procesos.Trabajos;
using System;

namespace Binapsis.Procesos.Actividades
{
    public class RecuperarModelo : Actividad
    {
        public RecuperarModelo(ActividadInfo actividadInfo) 
            : base(actividadInfo)
        {
        }

        public override void EjecutarActividad()
        {
            Type type = Parametros["type"] as Type;
            object[] items = Parametros["modelo"] as object[];
            IObjetoDatos modelo = null;

            if (items != null && items.Length == 1)
                modelo = items[0] as IObjetoDatos;

            Tipo tipo = HelperContext.TypeHelper.Obtener(type);
            object clave = modelo?.Obtener("Clave");

            EntidadRepositorio repositorio = new EntidadRepositorio();

            if (tipo != null && clave != null)
                modelo = repositorio.Recuperar(tipo, clave); //datos.Obtener(tipo, clave);
            else
                Cancelar();

            Parametros["modelo"] = modelo;
        }
    }
}
