using Binapsis.Plataforma.Configuracion.Sql.Clave;

namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    internal class SqlBuilderInsertarUri : SqlBuilderEscritura<Uri>
    {
        public SqlBuilderInsertarUri(Uri obj) 
            : base(obj)
        {
        }

        public override string ConstruirSql()
        {
            string PK_Uri = new ClaveUri(Objeto).ToString();
            string FK_Ensamblado = new ClaveEnsamblado(Objeto.Ensamblado).ToString();

            return $"Insert Into Uri (PK_Uri, FK_Ensamblado, Nombre) Values ('{PK_Uri}', '{FK_Ensamblado}', '{Objeto.Nombre}')";
        }
    }
}
