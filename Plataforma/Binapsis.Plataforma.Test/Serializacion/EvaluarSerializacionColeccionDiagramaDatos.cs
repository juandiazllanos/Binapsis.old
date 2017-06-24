using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion;
using Binapsis.Plataforma.Serializacion.Binario;
using Binapsis.Plataforma.Serializacion.Xml;
using Binapsis.Plataforma.Test.Serializacion.Helper;
using Binapsis.Plataforma.Test.Serializacion.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Test.Serializacion
{
    [TestClass]
    public class EvaluarSerializacionColeccionDiagramaDatos
    {
        [TestMethod, TestCategory("Serializacion Coleccion DiagramaDatos")]
        public void SerializarDiagramaDatosSimpleEnXml()
        {
            SerializarDiagramaDatos(CrearColeccionSimple(5), "xml");
        }

        [TestMethod, TestCategory("Serializacion Coleccion DiagramaDatos")]
        public void SerializarDiagramaDatosComplejoEnXml()
        {
            SerializarDiagramaDatos(CrearColeccionComplejo(5), "xml");
        }

        [TestMethod, TestCategory("Serializacion Coleccion DiagramaDatos")]
        public void SerializarDiagramaDatosSimpleEnBinario()
        {
            SerializarDiagramaDatos(CrearColeccionSimple(5), "bin");
        }

        [TestMethod, TestCategory("Serializacion Coleccion DiagramaDatos")]
        public void SerializarDiagramaDatosComplejoEnBinario()
        {
            SerializarDiagramaDatos(CrearColeccionComplejo(5), "bin");
        }
                
        void SerializarDiagramaDatos(IDiagramaDatos[] items, string formato)
        {
            ITipo tipo = items[0].Tipo;
            List<IDiagramaDatos> items2 = new List<IDiagramaDatos>();

            // serializar
            Serializar(items, formato);
            // deserializar
            Deserializar(tipo, items2, formato);
            // evaluar
            Evaluar(items, items2.ToArray());
        }

        void Evaluar(IDiagramaDatos[] items1, IDiagramaDatos[] items2)
        {
            Assert.AreEqual(items1.Length, items2.Length);

            for (int i = 0; i < items1.Length; i++)
                HelperDiagramaDatos.EvaluarDiagramaDatos(items1[i], items2[i]);
                //Assert.IsTrue(EqualityHelper.Instancia.Igual(items1[i], items2[i]));
        }

        #region CrearColeccion
        IDiagramaDatos[] CrearColeccionSimple(int items)
        {
            IDiagramaDatos[] od = new IDiagramaDatos[items];

            for (int i = 0; i < items; i++)
                od[i] = CrearDiagramaDatosSimple();

            return od;
        }

        IDiagramaDatos[] CrearColeccionComplejo(int items)
        {
            IDiagramaDatos[] od = new IDiagramaDatos[items];

            for (int i = 0; i < items; i++)
                od[i] = CrearDiagramaDatosComplejo();

            return od;
        }

        IDiagramaDatos CrearDiagramaDatosSimple()
        {
            IDiagramaDatos dd = new DiagramaDatos(HelperTipo.ObtenerTipo());
            HelperDiagramaDatos.ConstruirDiagramaDatosSimple(dd);
            return dd;
        }

        IDiagramaDatos CrearDiagramaDatosComplejo()
        {
            IDiagramaDatos dd = new DiagramaDatos(HelperTipo.ObtenerTipo2());
            HelperDiagramaDatos.ConstruirDiagramaDatosComplejo(dd);
            return dd;
        }
        #endregion


        #region Serializacion
        void Serializar(IDiagramaDatos[] items, string formato)
        {
            IEscritor escritor;
            ISecuencia secuencia;

            secuencia = new FicheroImpl($"items.{formato}");
            escritor = null;

            if (formato == "xml")
                escritor = new EscritorXml();
            else if (formato == "bin")
                escritor = new EscritorBinario();

            if (escritor != null)
                Serializar(items, secuencia, escritor);
        }
                
        void Serializar(IDiagramaDatos[] items, ISecuencia secuencia, IEscritor escritor)
        {
            Serializador serializador = new Serializador(secuencia, escritor);
            serializador.Serializar(items);
        }

        void Deserializar(ITipo tipo, List<IDiagramaDatos> items, string formato)
        {
            ILector lector;
            ISecuencia secuencia;

            secuencia = new FicheroImpl($"items.{formato}");
            lector = null;

            if (formato == "xml")
                lector = new LectorXml();
            else if (formato == "bin")
                lector = new LectorBinario();

            if (lector != null)
                Deserializar(tipo, items, secuencia, lector);
        }

        void Deserializar(ITipo tipo, List<IDiagramaDatos> items, ISecuencia secuencia, ILector lector)
        {
            Deserializador deserializador = new Deserializador(secuencia, lector);
            deserializador.Deserializar(tipo, items);
        }
        #endregion

    }
}
