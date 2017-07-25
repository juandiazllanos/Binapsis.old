using Binapsis.Plataforma.Datos.Mapeo;

namespace Binapsis.Plataforma.Datos.Impl
{
    class ParametroColumna : ParametroComando
    {
        public ParametroColumna(Plataforma.Configuracion.Parametro parametro) 
            : base(parametro)
        {
        }

        public MapeoColumna MapeoColumna
        {
            get;
            set;
        }
    }
}
