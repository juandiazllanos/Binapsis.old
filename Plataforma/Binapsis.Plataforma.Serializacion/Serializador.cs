using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion.Estrategia;
using Binapsis.Plataforma.Serializacion.Interno;
using System.IO;

namespace Binapsis.Plataforma.Serializacion
{
    public class Serializador
    {
        IEscritor _escritor;
        ISecuencia _secuencia;

        public Serializador(ISecuencia secuencia, IEscritor escritor)
        {
            _secuencia = secuencia;
            _escritor = escritor;            
        }

        /// <summary>
        /// Serializa el Objeto de datos enviado como parametro. Usando el escritor indicado el objeto de datos es representado en la secuencia establecida.
        /// </summary>		
        public void Serializar(IObjetoDatos od)
        {
            Serializar estrategia = new SerializarObjetoDatos(od, _escritor);
            Serializar(estrategia);            
        }

        public void Serializar(IDiagramaDatos dd)
        {
            Serializar estrategia = new SerializarDiagramaDatos(dd, _escritor);
            Serializar(estrategia);
        }

        public void Serializar(IObjetoDatos[] items)
        {
            Serializar estrategia = new SerializarColeccionObjetoDatos(items, _escritor);
            Serializar(estrategia);
        }

        public void Serializar(IDiagramaDatos[] items)
        {
            Serializar estrategia = new SerializarColeccionDiagramaDatos(items, _escritor);
            Serializar(estrategia);
        }

        private void Serializar(Serializar estrategia)
        {
            Stream stream = null;

            try
            {
                // crear stream
                stream = _secuencia.Stream;
                stream.SetLength(0);

                // establecer stream al escritor
                estrategia.Escritor.Stream = stream;

                // ejecutar operacion
                estrategia.Escribir();
            }
            finally
            {
                _secuencia.Cerrar();
            }
        }
        
	}

}