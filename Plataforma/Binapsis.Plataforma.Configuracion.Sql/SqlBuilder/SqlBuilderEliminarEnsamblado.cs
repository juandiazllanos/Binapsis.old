using System;
using Binapsis.Plataforma.Configuracion.Sql.Clave;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    internal class SqlBuilderEliminarEnsamblado : SqlBuilderEscritura<Ensamblado>
    {
        public SqlBuilderEliminarEnsamblado(Ensamblado obj) 
            : base(obj)
        {
        }
        
        public override string ConstruirSql()
        {
            return $"Delete From Ensamblado Where PK_Ensamblado = '{new ClaveEnsamblado(Objeto)}'";
        }
    }
}
