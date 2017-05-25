using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Configuracion.Sql.Helper
{
    public abstract class HelperBase<T> : IHelper where T : ObjetoBase
    {
        public HelperBase(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        public abstract void Actualizar(T obj);
        public abstract void Eliminar(T obj);
        public abstract bool Existe(T obj);
        public abstract bool Existe(string clave);
        public abstract void Insertar(T obj);
        public abstract void Recuperar(T obj, string clave);

        public string CadenaConexion { get; }

        #region IHelper
        void IHelper.Actualizar(ObjetoBase obj)
        {
            Actualizar((T)obj);
        }

        void IHelper.Eliminar(ObjetoBase obj)
        {
            Eliminar((T)obj);
        }

        bool IHelper.Existe(string clave)
        {
            return Existe(clave);
        }

        bool IHelper.Existe(ObjetoBase obj)
        {
            return Existe((T)obj);
        }

        void IHelper.Insertar(ObjetoBase obj)
        {
            Insertar((T)obj);
        }
                
        void IHelper.Recuperar(ObjetoBase obj, string clave)
        {
            Recuperar((T)obj, clave);
        }
        #endregion
    }
}
