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

        //public override void Construir()
        //{
        //    ConstruirMapeoColumnas();
        //    base.Construir();
        //}

        //private void ConstruirMapeoColumnas()
        //{
        //    if (MapeoTabla == null) return;

        //    var columnas = MapeoTabla.Columnas
        //        .Where(item => item.Columna.ClavePrimaria);

        //    MapeoColumnas.AddRange(columnas);
        //}

        protected override void ConstruirSentencia()
        {
            BuilderSentencia builder = new BuilderSentencia();

            builder.Agregar("DELETE FROM ").Agregar(MapeoTabla.Tabla.Nombre).Agregar(" ");
            builder.Agregar("WHERE ");

            // construir claves
            //var claves = MapeoColumnas.Select(item => item.Columna);
            int i = 0;

            foreach (MapeoColumna mapeoColumna in ParametroColumnas)
            {
                if (i++ != 0) builder.Agregar(" AND ");
                builder.Agregar(mapeoColumna.Columna.Nombre).Agregar("=")
                    .Agregar($"@{mapeoColumna.Columna.Nombre}");
            }

            Comando.Sql = builder.ToString();
            Comando.ComandoTipo = ComandoTipo.DELETE;
        }
                
        //protected override void ConstruirParametros()
        //{            
        //    foreach (MapeoColumna mapeoColumna in MapeoColumnas)
        //        ConstruirParametro(mapeoColumna);
        //}

        //private void ConstruirParametros(MapeoColumna mapeoColumna)
        //{
        //    Configuracion.Parametro parametro = Comando.CrearParametro(); 
        //    Columna columna = mapeoColumna.Columna;

        //    parametro.Nombre = columna.Nombre;
        //    parametro.Direccion = "IN";            
        //    //parametro.MapeoColumna = mapeoColumna;

        //    //Comando.Parametros.Agregar(parametro);
        //}

        private List<MapeoColumna> MapeoColumnas
        {
            get;
        }
    }
}
