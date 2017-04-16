using Binapsis.Plataforma.Estructura;
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
            Stream stream = null;
            Diagrama diag = null;
            BuilderDiagrama helper = new BuilderDiagrama();

            try
            {
                diag = helper.Crear(od);

                stream = _secuencia.Crear();
                stream.SetLength(0);

                _escritor.Stream = stream;
                _escritor.Escribir(diag.Root);
            }            
            finally
            {
                stream?.Dispose();
            }
        }
        
	}

}