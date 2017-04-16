using Binapsis.Plataforma.Estructura;
using System.IO;

namespace Binapsis.Plataforma.Serializacion
{
    public class Deserializador
    {
        ISecuencia _secuencia;
        ILector _lector;
        
        public Deserializador(ISecuencia secuencia, ILector lector)
        {
            _secuencia = secuencia;
            _lector = lector;
        }

        /// <summary>
        /// Deserializa la secuencia establecida en el Objeto de datos enviado como parametro. Usando el lector indicado el objeto de datos es representado desde la secuencia establecida.
        /// </summary>		
        public void Deserializar(IObjetoDatos od)
        {
            Stream stream = null;

            try
            {
                // inicializar secuencia
                stream = _secuencia.Crear();
                // inicializar lector
                _lector.Stream = stream;
                _lector.Leer(od);
            }
            finally
            {
                stream?.Dispose();
            }
        }

    }

}