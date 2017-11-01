using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Serializacion.Estrategia;
using System.Collections;
using System.IO;

namespace Binapsis.Plataforma.Serializacion
{
    public abstract class Deserializador
    {        
        public Deserializador(ISecuencia secuencia, ILector lector)
            : this(secuencia, lector, FabricaDatos.Instancia)
        {            
        }

        public Deserializador(ISecuencia secuencia, ILector lector, IFabrica fabrica)
        {
            Secuencia = secuencia;
            Lector = lector;
            Fabrica = fabrica;
        }

        /// <summary>
        /// Deserializa la secuencia establecida en el Objeto enviado como parametro. Usando el lector indicado el objeto es representado desde la secuencia establecida.
        /// </summary>		
        public abstract void Deserializar(object obj);

        /// <summary>
        /// Deserializa la secuencia establecida en la coleccion enviada como parametro. Usando el lector indicado la colección es representado desde la secuencia establecida.
        /// </summary>		
        public abstract void Deserializar(ITipo tipo, IList items);


        /// <summary>
        /// Deserializa la secuencia establecida usando la estrategia enviada como parametro.
        /// </summary>		
        internal void Deserializar(Deserializar estrategia)
        {
            if (Secuencia == null) return;

            Stream stream = null;

            try
            {
                // inicializar secuencia
                stream = Secuencia.Stream;
                // establecer stream al lector
                estrategia.Lector.Stream = stream;
                // ejecutar estrategia
                estrategia.Leer();
            }
            finally
            {
                Secuencia.Cerrar();
            }
        }

        protected ISecuencia Secuencia
        {
            get;
        }

        protected ILector Lector
        {
            get;
        }
        
        public IFabrica Fabrica
        {
            get;
            set;
        }
    }

}