using Binapsis.Plataforma.Configuracion.Sql.Comandos;

namespace Binapsis.Plataforma.Configuracion.Sql.Helper
{
    public abstract class HelperBase<T> : IHelper where T : ConfiguracionBase
    {
        public HelperBase(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        public abstract void Actualizar(string clave, T obj);
        public abstract void Eliminar(T obj);
        public abstract bool Existe(T obj);
        public abstract bool Existe(string clave);
        public abstract void Insertar(T obj);
        public abstract T Recuperar(string clave);

        internal bool Existe(ISqlBuilder builder)
        {
            ComandoExiste comando = new ComandoExiste(builder);
            Ejecutar(comando);
            return comando.Resultado;
        }

        internal void Escribir(ISqlBuilder builder)
        {
            Escribir(builder, null);
        }

        internal void Escribir(ISqlBuilder builder, Contexto contexto)
        {
            Ejecutar(new ComandoEscritura(builder), contexto);
        }

        internal void Ejecutar(ComandoBase comando)
        {
            Ejecutar(comando, null);
        }

        internal void Ejecutar(ComandoBase comando, Contexto contexto)
        {
            if (contexto == null) contexto = new Contexto(CadenaConexion);
            comando.Contexto = contexto;
            contexto.Ejecutar(comando);
        }

        public string CadenaConexion { get; }

        #region IHelper
        void IHelper.Actualizar(string clave, ConfiguracionBase obj)
        {
            Actualizar(clave, (T)obj);
        }

        void IHelper.Eliminar(ConfiguracionBase obj)
        {
            Eliminar((T)obj);
        }

        bool IHelper.Existe(string clave)
        {
            return Existe(clave);
        }

        bool IHelper.Existe(ConfiguracionBase obj)
        {
            return Existe((T)obj);
        }

        void IHelper.Insertar(ConfiguracionBase obj)
        {
            Insertar((T)obj);
        }

        ConfiguracionBase IHelper.Recuperar(string clave)
        {
            return Recuperar(clave);
        }        
        #endregion
    }
}
