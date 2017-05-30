using Binapsis.Plataforma.Configuracion.Sql.Clave;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    class SqlBuilderSeleccionarColumnaTabla : SqlBuilderSeleccion
    {
        public SqlBuilderSeleccionarColumnaTabla(Tabla tabla) 
            : base(new ClaveTabla(tabla).ToString())
        {
        }

        protected override string ConstruirSelect()
        {
            return "";
        }

        protected override string ConstruirSelectWhere(string clave)
        {
            return $"Select * From Columna Where FK_Tabla = '{clave}'";
        }
    }
}
