namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    internal class SqlBuilderSeleccionarPropiedad : SqlBuilderSeleccion
    {
        public SqlBuilderSeleccionarPropiedad(string clave) 
            : base(clave)
        {
        }

        protected override string ConstruirSelect()
        {
            return "";
        }

        protected override string ConstruirSelectWhere(string clave)
        {
            return $"Select Top 1 PK_Propiedad, FK_Tipo_Propietario, FK_Tipo_Tipo, Alias, Asociacion, Cardinalidad, Indice, Nombre, ValorInicial From Propiedad Where PK_Propiedad = '{clave}'";
        }
    }
}
