namespace Binapsis.Plataforma.Configuracion.Sql.SqlBuilder
{
    internal abstract class SqlBuilderEscritura<T> : ISqlBuilder
    {
        T _obj;

        public SqlBuilderEscritura(T obj)
        {
            _obj = obj;
        }

        protected T Objeto
        {
            get { return _obj; }
        }

        public abstract string ConstruirSql();
    }
}
