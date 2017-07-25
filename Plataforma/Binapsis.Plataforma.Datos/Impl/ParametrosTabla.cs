using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos.Mapeo;

namespace Binapsis.Plataforma.Datos.Impl
{
    public class ParametrosTabla : Parametros
    {
        internal ParametrosTabla(Comando comando, MapeoTabla mapeoTabla) 
            : base(comando)
        {
            ConstruirParametros(comando, mapeoTabla);
        }

        protected override void ConstruirParametros(Comando comando)
        {
            return;            
        }

        private void ConstruirParametros(Comando comando, MapeoTabla mapeoTabla)
        {
            foreach (Parametro parametro in comando.Parametros)
                AgregarParametro(CrearParametro(parametro, mapeoTabla?.ObtenerMapeoColumnaPorColumna(parametro.Nombre)));
        }

        private ParametroComando CrearParametro(Parametro parametro, MapeoColumna mapeoColumna)
        {
            if (mapeoColumna == null)
                return base.CrearParametro(parametro);
            else 
                return new ParametroColumna(parametro) { MapeoColumna = mapeoColumna };            
        }
        
    }
}
