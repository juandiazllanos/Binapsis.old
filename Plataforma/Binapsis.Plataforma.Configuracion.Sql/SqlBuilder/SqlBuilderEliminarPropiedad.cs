using Binapsis.Plataforma.Configuracion.Sql.Clave;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    internal class SqlBuilderEliminarPropiedad : SqlBuilderEscritura<Propiedad>
    {
        public SqlBuilderEliminarPropiedad(Propiedad obj) 
            : base(obj)
        {
        }

        public override string ConstruirSql()
        {            
            return $"Delete From Propiedad Where PK_Propiedad = '{new ClavePropiedad(Objeto)}'";
        }
    }
}
