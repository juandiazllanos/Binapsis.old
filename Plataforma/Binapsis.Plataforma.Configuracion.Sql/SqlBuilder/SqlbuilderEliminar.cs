using Binapsis.Plataforma.Configuracion.Sql.Clave;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    class SqlBuilderEliminar : SqlBuilderEscritura<ConfiguracionBase>
    {
        public SqlBuilderEliminar(ConfiguracionBase obj) 
            : this(ClaveBase.Crear(obj)?.ToString(), obj)
        {
        }

        public SqlBuilderEliminar(string clave, ConfiguracionBase obj)
            : base(obj)
        {
            Clave = clave;
        }

        public override string ConstruirSql()
        {
            return $"Delete from {Objeto.Tipo.Nombre} Where PK_{Objeto.Tipo.Nombre} = '{Clave}'";
        }

        public string Clave
        {
            get;
            set;
        }
    }
}
