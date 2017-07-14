namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    class SqlBuilderSeleccionarRelacion : ISqlBuilder
    {
        public string ConstruirSql()
        {
            SqlBuilderFiltro builder = new SqlBuilderFiltro();

            builder.Agregar("tablaPrincipal", TablaPrincipal);
            builder.Agregar("tablaSecundaria", TablaSecundaria);

            if (!string.IsNullOrEmpty(Uri) && !string.IsNullOrEmpty(Tipo))
                builder.Agregar("tipo", $"{Uri}.{Tipo}");

            builder.Agregar("propiedad", Propiedad);

            string filtro = builder.ToString();
            string sql = "select * from relacion";

            if (!string.IsNullOrEmpty(filtro)) sql += $" where {filtro}";

            return sql;            
        }

        public string TablaPrincipal
        {
            get;
            set;
        }

        public string TablaSecundaria
        {
            get;
            set;
        }

        public string Propiedad
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
