using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using System.Linq;
using Binapsis.Plataforma.Configuracion;
using System.Collections.Generic;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Datos.Builder
{
    class BuilderComandoUpdate : BuilderComando
    {        

        public BuilderComandoUpdate(Comando comando) 
            : base(comando)
        {
            MapeoColumnas = new List<MapeoColumna>();
        }

        public override void Construir()
        {
            if (MapeoTabla == null || Cambios == null || Cambios.Count == 0) return;

            ConstruirMapeoColumnas();
            base.Construir();
        }

        private void ConstruirMapeoColumnas()
        {                        
            foreach (IPropiedad propiedad in Cambios.OrderBy(item => item.Nombre))
                MapeoColumnas.Add(MapeoTabla.ObtenerMapeoColumnaPorPropiedad(propiedad.Nombre));

            var claves = MapeoTabla.Columnas
                .Where(item => item.Columna.ClavePrimaria && !MapeoColumnas.Contains(item));                

            MapeoColumnas.AddRange(claves);
        }

        protected override void ConstruirSentencia()
        {
            BuilderSentencia builder = new BuilderSentencia();

            builder.Agregar("UPDATE ").Agregar(MapeoTabla.Tabla.Nombre).Agregar(" ");
            builder.Agregar("SET ");

            // construir campos
            var campos = MapeoColumnas.Where(item => !item.Columna.ClavePrimaria).Select(item => item.Columna);
            int i = 0;

            foreach (Columna columna in campos)
            {
                if (i++ != 0) builder.Agregar(", ");
                builder.Agregar(columna.Nombre)
                    .Agregar("=").Agregar($"@{columna.Nombre}");
            }

            builder.Agregar(" ");
            builder.Agregar("WHERE ");

            // construir condicion
            var claves = MapeoColumnas.Where(item => item.Columna.ClavePrimaria).Select(item => item.Columna);

            i = 0;
            foreach (Columna columna in claves)
            {
                if (i++ != 0) builder.Agregar(" AND ");
                builder.Agregar(columna.Nombre).Agregar("=").Agregar($"@{columna.Nombre}");
            }

            Comando.Sql = builder.ToString();
        }
        
        protected override void ConstruirParametros()
        {            
            foreach (MapeoColumna mapeoColumna in MapeoColumnas)
                ConstruirParametro(mapeoColumna);
        }

        private void ConstruirParametro(MapeoColumna mapeoColumna)
        {
            ParametroColumna parametro = new ParametroColumna();
            Columna columna = mapeoColumna.Columna;

            parametro.Nombre = columna.Nombre;
            parametro.Direccion = "IN";
            parametro.MapeoColumna = mapeoColumna;

            Comando.Parametros.Agregar(parametro);
        }

        public IList<IPropiedad> Cambios
        {
            get;
            set;
        }

        private List<MapeoColumna> MapeoColumnas
        {
            get;
        }
    }
}
