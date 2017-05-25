using Binapsis.Plataforma.Configuracion.Sql.Clave;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    internal class SqlBuilderEliminarTipo : SqlBuilderEscritura<Tipo>
    {
        public SqlBuilderEliminarTipo(Tipo obj) 
            : base(obj)
        {
        }

        public override string ConstruirSql()
        {
            return $"Delete From Tipo Where PK_Tipo = '{new ClaveTipo(Objeto)}'";
        }
    }
}
