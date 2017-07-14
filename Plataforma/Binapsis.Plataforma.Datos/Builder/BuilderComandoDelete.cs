using Binapsis.Plataforma.Datos.Impl;
using System.Linq;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos.Mapeo;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Datos.Builder
{
    class BuilderComandoDelete : BuilderComando
    {
        public BuilderComandoDelete(Comando comando) 
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
                .Where(item => item.Columna.ClavePrimaria);

            MapeoColumnas.AddRange(columnas);
        }

        protected override void ConstruirSentencia()
        {
            BuilderSentencia builder = new BuilderSentencia();

            builder.Agregar("DELETE FROM ").Agregar(MapeoTabla.Tabla.Nombre).Agregar(" ");
            builder.Agregar("WHERE ");

            // construir claves
            var claves = MapeoColumnas.Select(item => item.Columna);
            int i = 0;

            foreach (Columna columna in claves)
            {
                if (i++ != 0) builder.Agregar(" AND ");
                builder.Agregar(columna.Nombre).Agregar("=")
                    .Agregar($"@{columna.Nombre}");
            }

            Comando.Sql = builder.ToString();
        }
                
        protected override void ConstruirParametros()
        {            
            foreach (MapeoColumna mapeoColumna in MapeoColumnas)
                ConstruirParametros(mapeoColumna);
        }

        private void ConstruirParametros(MapeoColumna mapeoColumna)
        {
            ParametroColumna parametro = new ParametroColumna();
            Columna columna = mapeoColumna.Columna;

            parametro.Nombre = columna.Nombre;
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
