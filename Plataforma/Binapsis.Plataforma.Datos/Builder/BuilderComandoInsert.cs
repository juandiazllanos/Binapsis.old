using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Configuracion;
using System.Linq;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Datos.Builder
{
    class BuilderComandoInsert : BuilderComando
    {
        public BuilderComandoInsert(Comando comando)
            : base(comando)
        {
            MapeoColumnas = new List<MapeoColumna>();
        }

        public override void Construir()
        {
            ConstruirMapeoColumnas();
            base.Construir();
        }

        private void ConstruirMapeoColumnas()
        {
            if (MapeoTabla == null) return;

            var columnas = MapeoTabla.Columnas
                .OrderBy(item => item.Columna.ClavePrimaria)
                .OrderBy(item => item.Columna.Nombre);            

            MapeoColumnas.AddRange(columnas);
        }

        protected override void ConstruirSentencia()
        {
            BuilderSentencia builder = new BuilderSentencia();

            // escribir declaracion
            builder.Agregar("INSERT INTO ")
                .Agregar($"{MapeoTabla.Tabla.Nombre} ( ");

            // escribir campos
            int i = 0;

            foreach (MapeoColumna mapeoColumna in MapeoColumnas)
            {
                if (i++ != 0) builder.Agregar(", ");
                builder.Agregar(mapeoColumna.Columna.Nombre);
            }

            builder.Agregar(" ) ");

            // escribir parametros
            builder.Agregar("VALUES ( ");

            i = 0;
            foreach (MapeoColumna mapeoColumna in MapeoColumnas)
            {
                if (i++ != 0) builder.Agregar(", ");
                builder.Agregar($"@{mapeoColumna.Columna.Nombre}");
            }

            builder.Agregar(" )");

            // establecer sql
            Comando.Sql = builder.ToString();
        }
        
        protected override void ConstruirParametros()
        {
            foreach (MapeoColumna mapeoColumna in MapeoColumnas)
                CrearParametro(mapeoColumna);
        }

        private void CrearParametro(MapeoColumna mapeoColumna)
        {
            Columna columna = mapeoColumna.Columna;
            ParametroColumna parametro = new ParametroColumna();

            parametro.Nombre = columna.Nombre;
            //parametro.Type = mapeoColumna.Propiedad.Tipo;
            parametro.Direccion = "IN";
            parametro.MapeoColumna = mapeoColumna;

            Comando.Parametros.Agregar(parametro);
        }

        private List<MapeoColumna> MapeoColumnas
        {
            get;
        }
    }
}
