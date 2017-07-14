using Binapsis.Plataforma.Serializacion;
using System;
using System.IO;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public abstract class SerializacionBase : ISerializador 
    {
        ConfiguracionBase _objeto;
        byte[] _contenido;

        public SerializacionBase(Type type)
        {
            _objeto = Fabrica.Instancia.Crear(type);
        }

        public SerializacionBase(ConfiguracionBase objeto)
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
            Serializador helper = new SerializadorObjetoDatos(secuencia, escritor);
            helper.Serializar(_objeto);
            _contenido = secuencia.Contenido;
        }
        #endregion


        #region Propiedades
        public ConfiguracionBase Objeto
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

        //ConfiguracionBase ISerializador.Objeto
        //{
        //    get { return Objeto; }
        //}
        #endregion
    }
}
