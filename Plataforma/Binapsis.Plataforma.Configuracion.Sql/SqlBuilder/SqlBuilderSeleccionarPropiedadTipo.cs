namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    internal class SqlBuilderSeleccionarPropiedadTipo : SqlBuilderSeleccion
    {
        public SqlBuilderSeleccionarPropiedadTipo(string clave) 
            : base(clave)
        {
        }

        protected override string ConstruirSelect()
        {
            return "";
        }

        protected override string ConstruirSelectWhere(string clave)
        {
            return $"Select PK_Propiedad, FK_Tipo_Propietario, FK_Tipo_Tipo, Alias, Asociacion, Cardinalidad, Indice, Nombre, ValorInicial From Propiedad Where FK_Tipo_Propietario = '{clave}'";
        }
    }
}
