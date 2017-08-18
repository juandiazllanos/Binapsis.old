using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;
using System;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Actividades
{
    public class Recuperar : Actividad
    {
        public override void Iniciar()
        {
            Type type = Parametros["type"] as Type;
            Clave clave = Parametros["clave"] as Clave;

            Repositorio repositorio = Contexto.Repositorio;
            ConfiguracionBase instancia = null;

            if (type != null && clave != null && repositorio != null)
                instancia = repositorio.Obtener(type, clave.Valor);
                        
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
