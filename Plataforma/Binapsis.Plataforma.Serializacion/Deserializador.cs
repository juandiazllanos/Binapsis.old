using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Serializacion.Estrategia;
using Binapsis.Plataforma.Serializacion.Interno;
using System;
using System.Collections.Generic;
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
            Fabrica = FabricaDatos.Instancia;
        }

        /// <summary>
        /// Deserializa la secuencia establecida en el Objeto de datos enviado como parametro. Usando el lector indicado el objeto de datos es representado desde la secuencia establecida.
        /// </summary>		
        public void Deserializar(IObjetoDatos od)
        {
            DeserializarObjetoDatos estrategia = new DeserializarObjetoDatos(od, _lector);

            estrategia.Fabrica = Fabrica;
            estrategia.HeapId = new HeapId();
            
            Deserializar(estrategia);
        }

        public void Deserializar(IDiagramaDatos dd)
        {
            DeserializarDiagramaDatos estrategia = new DeserializarDiagramaDatos(dd, _lector);

            estrategia.Fabrica = Fabrica;
            estrategia.HeapId = new HeapId();

            Deserializar(estrategia);
        }

        public void Deserializar(ITipo tipo, List<IObjetoDatos> items)
        {
            DeserializarColeccionObjetoDatos estrategia = new DeserializarColeccionObjetoDatos(tipo, items, _lector);

            estrategia.Fabrica = Fabrica;
            estrategia.HeapId = new HeapId();

            Deserializar(estrategia);
        }

        public void Deserializar(ITipo tipo, List<IDiagramaDatos> items)
        {
            DeserializarColeccionDiagramaDatos estrategia = new DeserializarColeccionDiagramaDatos(tipo, items, _lector);

            estrategia.Fabrica = Fabrica;
            estrategia.HeapId = new HeapId();

            Deserializar(estrategia);
        }

        private void Deserializar(Deserializar estrategia)
        {
            Stream stream = null;

            try
            {
                // inicializar secuencia
                stream = _secuencia.Stream;
                // establecer stream al lector
                estrategia.Lector.Stream = stream;
                // ejecutar estrategia
                estrategia.Leer();
            }
            finally
            {
                _secuencia.Cerrar();
            }
        }

        public IFabrica Fabrica
        {
            get;
            set;
        }
    }

}