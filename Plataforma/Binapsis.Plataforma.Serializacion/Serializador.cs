using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion.Estrategia;
using System.Collections.Generic;
using System.IO;

namespace Binapsis.Plataforma.Serializacion
{
    public class Serializador
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
        public virtual void Serializar(object obj)
        {
            Serializar estrategia = null;

            if (obj is IObjetoDatos od)
                estrategia = new SerializarObjetoDatos(od, Escritor);
            else if (obj is IDiagramaDatos dd)
                estrategia = new SerializarDiagramaDatos(dd, Escritor);
            else if (obj is IEnumerable<IObjetoDatos> odItems)
                estrategia = new SerializarColeccionObjetoDatos(odItems, Escritor);
            else if (obj is IEnumerable<IDiagramaDatos> ddItems)
                estrategia = new SerializarColeccionDiagramaDatos(ddItems, Escritor);

            if (estrategia != null)
                Serializar(estrategia);
        }
        
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