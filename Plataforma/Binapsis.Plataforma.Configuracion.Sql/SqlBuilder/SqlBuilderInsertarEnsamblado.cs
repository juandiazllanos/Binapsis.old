using Binapsis.Plataforma.Configuracion.Sql.Clave;
using System;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    internal class SqlBuilderInsertarEnsamblado : SqlBuilderEscritura<Ensamblado>
    {
        public SqlBuilderInsertarEnsamblado(Ensamblado obj) 
            : base(obj)
        {
        }

        
        public override string ConstruirSql()
        {
            return $"Insert into Ensamblado (PK_Ensamblado, Nombre) Values ('{new ClaveEnsamblado(Objeto)}', '{Objeto.Nombre}')";
        }
    }
}
