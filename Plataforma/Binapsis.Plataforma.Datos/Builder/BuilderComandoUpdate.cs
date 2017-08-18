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
        }

        public override void Construir()
        {
            if (MapeoTabla == null || Cambios == null || Cambios.Count == 0) return;            
            base.Construir();
        }

        protected override void ConstruirParametroColumnas()
        {
            base.ConstruirParametroColumnas();

            MapeoColumna mapeoColumna;

            foreach (IPropiedad propiedad in Cambios.OrderBy(item => item.Nombre))
            {
                mapeoColumna = MapeoTabla.ObtenerMapeoColumnaPorPropiedad(propiedad.Nombre);

                if (!ParametroColumnas.Contains(mapeoColumna))
                    ParametroColumnas.Add(mapeoColumna);
            }

        }
        
        protected override void ConstruirSentencia()
        {
            BuilderSentencia builder = new BuilderSentencia();

            builder.Agregar("UPDATE ").Agregar(MapeoTabla.Tabla.Nombre).Agregar(" ");
            builder.Agregar("SET ");

            // construir campos
            var campos = ParametroColumnas.Where(item => !item.Columna.ClavePrimaria).Select(item => item.Columna);
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
            var claves = ParametroColumnas.Where(item => item.Columna.ClavePrimaria).Select(item => item.Columna);

            i = 0;
            foreach (Columna columna in claves)
            {
                if (i++ != 0) builder.Agregar(" AND ");
                builder.Agregar(columna.Nombre).Agregar("=").Agregar($"@{columna.Nombre}");
            }

            Comando.Sql = builder.ToString();
            Comando.ComandoTipo = ComandoTipo.UPDATE;
        }
        
        public IList<IPropiedad> Cambios
        {
            get;
            set;
        }        
    }
}
