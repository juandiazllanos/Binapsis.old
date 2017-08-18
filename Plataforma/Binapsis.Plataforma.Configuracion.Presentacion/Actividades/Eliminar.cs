using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;
using System;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Actividades
{
    public class Eliminar : Actividad
    {
        public override void Iniciar()
        {
            Type type = Parametros["type"] as Type;
            Clave clave = Parametros["clave"] as Clave;
            Repositorio repositorio = Contexto.Repositorio;

            if (type != null && clave != null)
                repositorio.Eliminar(type, clave.Valor);

            Terminar();
        }
    }
}
