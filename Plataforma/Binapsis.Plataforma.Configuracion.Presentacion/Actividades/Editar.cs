using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Actividades
{
    public class Editar : Actividad
    {
        public override void Iniciar()
        {
            ConfiguracionBase instancia = Parametros["instancia"] as ConfiguracionBase;
            Clave clave = Parametros["clave"] as Clave;
            Repositorio repositorio = Contexto.Repositorio;

            if (instancia != null && clave != null)
                repositorio.Editar(instancia, clave.Valor);

            Terminar();
        }
    }
}
