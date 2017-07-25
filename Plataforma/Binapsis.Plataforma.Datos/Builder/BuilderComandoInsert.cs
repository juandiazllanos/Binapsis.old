using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Configuracion;
using System.Linq;

namespace Binapsis.Plataforma.Datos.Builder
{
    class BuilderComandoInsert : BuilderComando
    {
        public BuilderComandoInsert(Comando comando)
            : base(comando)
        {            
        }
        
        protected override void ConstruirParametroColumnas()
        {
            var columnas = MapeoTabla.Columnas
                .OrderBy(item => item.Columna.ClavePrimaria)
                .OrderBy(item => item.Columna.Nombre);

            foreach(MapeoColumna mapeoColumna in columnas)
                ParametroColumnas.Add(mapeoColumna);
        }
        
        protected override void ConstruirSentencia()
        {
            BuilderSentencia builder = new BuilderSentencia();

            // escribir declaracion
            builder.Agregar("INSERT INTO ")
                .Agregar($"{MapeoTabla.Tabla.Nombre} ( ");

            // escribir campos
            int i = 0;

            foreach (MapeoColumna mapeoColumna in ParametroColumnas)
            {
                if (i++ != 0) builder.Agregar(", ");
                builder.Agregar(mapeoColumna.Columna.Nombre);
            }

            builder.Agregar(" ) ");

            // escribir parametros
            builder.Agregar("VALUES ( ");

            i = 0;
            foreach (MapeoColumna mapeoColumna in ParametroColumnas)
            {
                if (i++ != 0) builder.Agregar(", ");
                builder.Agregar($"@{mapeoColumna.Columna.Nombre}");
            }

            builder.Agregar(" )");

            // establecer sql
            Comando.Sql = builder.ToString();
        }

    }
}
