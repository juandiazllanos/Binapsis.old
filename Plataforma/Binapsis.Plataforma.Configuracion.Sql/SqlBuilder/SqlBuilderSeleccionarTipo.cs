namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    internal class SqlBuilderSeleccionarTipo : SqlBuilderSeleccion
    {
        public SqlBuilderSeleccionarTipo(string clave) 
            : base(clave)
        {
        }

        protected override string ConstruirSelect()
        {
            return $"Select PK_Tipo, FK_Tipo_Base, FK_Uri, Alias, EsTipoDeDato, Nombre From Tipo";
        }

        protected override string ConstruirSelectWhere(string clave)
        {
            return $"Select Top 1 PK_Tipo, FK_Tipo_Base, FK_Uri, Alias, EsTipoDeDato, Nombre From Tipo Where PK_Tipo = '{clave}'";
        }
    }
}
