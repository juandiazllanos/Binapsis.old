using Binapsis.Plataforma.Configuracion.Sql.Clave;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    class SqlBuilderActualizarEnsamblado : SqlBuilderEscritura<Ensamblado>
    {
        string _clave;

        public SqlBuilderActualizarEnsamblado(string clave, Ensamblado obj)
            : base(obj)
        {
            _clave = clave;
        }

        public override string ConstruirSql()
        {
            return $"Update Ensamblado Set Nombre = '{Objeto.Nombre}', PK_Ensamblado = '{new ClaveEnsamblado(Objeto)}' Where PK_Ensamblado = '{_clave}'";
        }
    }
}
