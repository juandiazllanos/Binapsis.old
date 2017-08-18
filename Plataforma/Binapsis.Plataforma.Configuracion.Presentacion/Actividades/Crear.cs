namespace Binapsis.Plataforma.Configuracion.Presentacion.Actividades
{
    public class Crear : Actividad
    {
        public override void Iniciar()
        {            
            ConfiguracionBase instancia = Parametros["instancia"] as ConfiguracionBase;
            Repositorio repositorio = Contexto.Repositorio;

            if (instancia != null)
                repositorio.Crear(instancia);

            Terminar();
        }
    }
}
