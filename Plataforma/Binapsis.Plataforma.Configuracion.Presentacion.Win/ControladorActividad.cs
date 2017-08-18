using Binapsis.Plataforma.Configuracion.Presentacion.Actividades;
using System;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win
{
    class ControladorActividad : IFabrica
    {
        public object Crear()
        {
            throw new NotImplementedException();
        }

        public object Crear(params object[] param)
        {
            if (param.Length == 0) return null;

            Type type = param[0] as Type;
            object instancia = null;

            object[] args = null;

            // determinar parametros en constructor
            if (type == typeof(Mostrar) || type.IsSubclassOf(typeof(Mostrar)))
                args = new object[] { "vistaEntidad" };
            else if (type == typeof(Seleccionar))
                args = new object[] { "vistaSeleccionar" };

            // instanciar
            if (args == null)
                instancia = Activator.CreateInstance(type);
            else
                instancia = Activator.CreateInstance(type, args);

            return instancia;
        }
    }
}
