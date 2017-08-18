using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos.Mapeo;

namespace Binapsis.Plataforma.Datos.Builder
{
    class BuilderComandoSelect : BuilderComando
    {
        public BuilderComandoSelect(Comando comando) 
            : base(comando)
        {
        }
        
        protected override void ConstruirSentencia()
        {
            BuilderSentencia builder = new BuilderSentencia();

            builder.Agregar("SELECT *");            

            builder.Agregar(" FROM ").Agregar(MapeoTabla.Tabla.Nombre);
            builder.Agregar(" WHERE ");

            int i = 0;
            foreach (MapeoColumna mapeoColumna in ParametroColumnas)
            {
                if (i++ > 0) builder.Agregar(" AND ");
                builder.Agregar(mapeoColumna.Columna.Nombre).Agregar("=").Agregar($"@{mapeoColumna.Columna.Nombre}");
            }                

            Comando.Sql = builder.ToString();
            Comando.ComandoTipo = ComandoTipo.QUERY;
        }
        
    }
}
