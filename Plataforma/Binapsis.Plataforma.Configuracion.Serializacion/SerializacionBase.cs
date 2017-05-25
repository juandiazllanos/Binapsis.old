using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Serializacion;
using System.IO;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public abstract class SerializacionBase<T> : ISerializador where T : ObjetoBase
    {
        T _objeto;
        byte[] _contenido;

        public SerializacionBase()
        {
            _objeto = (T)FabricaConfiguracion.Instancia.Crear(typeof(T));
        }

        public SerializacionBase(T objeto)
        {
            _objeto = objeto;
        }

        #region Serializacion
        public void Serializar()
        {
            Serializar(new Secuencia());
        }

        public void Serializar(Stream contenido)
        {
            Serializar(new Secuencia(contenido));
        }

        protected abstract void Serializar(Secuencia secuencia);

        protected void Serializar(Secuencia secuencia, IEscritor escritor)
        {
            Serializador helper = new Serializador(secuencia, escritor);
            helper.Serializar(_objeto);
            _contenido = secuencia.Contenido;
        }
        #endregion


        #region Propiedades
        public T Objeto
        {
            get { return _objeto; }
        }

        public byte[] Contenido
        {
            get { return _contenido; }
        }
        #endregion


        #region ISerializador
        void ISerializador.Serializar()
        {
            Serializar();
        }

        void ISerializador.Serializar(Stream contenido)
        {
            Serializar(contenido);
        }

        byte[] ISerializador.Contenido
        {
            get { return Contenido; }
        }

        ObjetoBase ISerializador.Objeto
        {
            get { return Objeto; }
        }
        #endregion
    }
}
