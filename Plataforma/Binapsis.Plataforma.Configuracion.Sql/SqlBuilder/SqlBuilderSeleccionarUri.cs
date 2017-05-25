namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    internal class SqlBuilderSeleccionarUri : SqlBuilderSeleccion
    {
        public SqlBuilderSeleccionarUri()
        {
        }

        public SqlBuilderSeleccionarUri(string clave) 
            : base(clave)
        {
        }

        protected override string ConstruirSelect()
        {
            return "Select PK_Uri, FK_Ensamblado, Nombre From Uri";
        }

        protected override string ConstruirSelectWhere(string clave)
        {
            return $"Select top 1 PK_Uri, FK_Ensamblado, Nombre From Uri Where PK_Uri = '{clave}'";
        }
    }
}
