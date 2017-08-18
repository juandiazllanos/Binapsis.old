using System;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Actividades
{
    public class Instanciar : Actividad
    {
        public override void Iniciar()
        {
            Type type = Parametros["type"] as Type;
            IFabrica fabrica = Contexto.ObtenerFabrica("entidad");

            ConfiguracionBase instancia = null;

            if (type != null && fabrica != null)
                instancia = fabrica.Crear(type) as ConfiguracionBase;

            if (instancia != null)
            {
                Parametros["instancia"] = instancia;
                Terminar();
            }
            else
                Cancelar();

        }
    }
}
