using Binapsis.Plataforma.Serializacion;
using System.IO;
using System;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public abstract class DeserializacionBase : IDeserializador
    {
        ConfiguracionBase _objeto;
        byte[] _contenido;
        
        public DeserializacionBase(Type type)
        {
            _objeto = Fabrica.Instancia.Crear(type);
        }

        public DeserializacionBase(ConfiguracionBase objeto)
        {
            _objeto = objeto;
        }

        #region Deserializacion
        public void Deserializar(byte[] contenido)
        {
            Deserializar(new Secuencia(contenido));            
        }
        
        public void Deserializar(string contenido)
        {
            Deserializar(new Secuencia(contenido));
        }
        
        public void Deserializar(Stream contenido)
        {
            Deserializar(new Secuencia(contenido));
        }

        protected abstract void Deserializar(Secuencia secuencia);

        protected void Deserializar(Secuencia secuencia, ILector lector)
        {
            Deserializador helper = new DeserializadorObjetoDatos(secuencia, lector);
            helper.Fabrica = Fabrica.Instancia;
            helper.Deserializar(_objeto);
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


        #region IDeserializador
        void IDeserializador.Deserializar(string contenido)
        {
            Deserializar(contenido);
        }

        void IDeserializador.Deserializar(Stream contenido)
        {
            Deserializar(contenido);
        }

        void IDeserializador.Deserializar(byte[] contenido)
        {
            Deserializar(contenido);
        }

        //ConfiguracionBase IDeserializador.Objeto
        //{
        //    get { return Objeto; }
        //}
        #endregion

    }
}
