using Binapsis.Plataforma.Configuracion.Sql.Clave;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    internal class SqlBuilderEliminarUri : SqlBuilderEscritura<Uri>
    {
        public SqlBuilderEliminarUri(Uri obj) 
            : base(obj)
        {
        }

        public override string ConstruirSql()
        {
            return $"Delete From Uri Where PK_Uri = '{new ClaveUri(Objeto)}'";
        }
    }
}
