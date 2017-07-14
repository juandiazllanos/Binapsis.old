using Binapsis.Plataforma.Serializacion.Estrategia;
using System.IO;

namespace Binapsis.Plataforma.Serializacion
{
    public abstract class Serializador
    {
        public Serializador(ISecuencia secuencia, IEscritor escritor)
        {
            Secuencia = secuencia;
            Escritor = escritor;            
        }

        public IEscritor Escritor
        {
            get;
        }

        public ISecuencia Secuencia
        {
            get;
        }

        /// <summary>
        /// Serializa el Objeto de datos enviado como parametro. Usando el escritor indicado el objeto de datos es representado en la secuencia establecida.
        /// </summary>
        public abstract void Serializar(object obj);

                
        internal void Serializar(Serializar estrategia)
        {
            Stream stream = null;

            if (Secuencia == null) return;

            try
            {
                // crear stream
                stream = Secuencia.Stream;
                stream.SetLength(0);

                // establecer stream al escritor
                estrategia.Escritor.Stream = stream;

                // ejecutar operacion
                estrategia.Escribir();
            }
            finally
            {
                Secuencia.Cerrar();
            }
        }
        
	}

}