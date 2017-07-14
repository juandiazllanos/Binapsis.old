using System;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    class SqlBuilderSeleccionarTabla : ISqlBuilder
    {        
        public string ConstruirSql()
        {
            string filtro = string.Empty;
            string sql = string.Empty;

            if (!string.IsNullOrEmpty(Nombre))
                filtro = $"nombre = '{Nombre}'";

            if (!string.IsNullOrEmpty(Uri) && !string.IsNullOrEmpty(Tipo))
                filtro = !string.IsNullOrEmpty(filtro) ? "and " : "" + $"tipo = '{Uri}.{Tipo}'";

            sql = "select * from tabla";

            if (!string.IsNullOrEmpty(filtro))
                sql += " where " + filtro;

            return sql;
        }

        public string Nombre
        {
            get;
            set;
        }

        public string Tipo
        {
            get;
            set;
        }

        public string Uri
        {
            get;
            set;
        }
    }
}
