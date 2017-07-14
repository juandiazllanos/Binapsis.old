using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper.Impl;
using Binapsis.Plataforma.Serializacion;
using Binapsis.Plataforma.Serializacion.Binario;
using Binapsis.Plataforma.Serializacion.Xml;
using Binapsis.Plataforma.Test.Serializacion.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Test.Serializacion
{
    [TestClass]
    public class EvaluarSerializacionColeccionObjetoDatos
    {
        [TestMethod, TestCategory("Serializacion Coleccion ObjetoDatos")]
        public void SerializarObjetoDatosSimpleEnXml()
        {
            SerializarObjetoDatos(CrearColeccionSimple(5), "xml");
        }

        [TestMethod, TestCategory("Serializacion Coleccion ObjetoDatos")]
        public void SerializarObjetoDatosComplejoEnXml()
        {
            SerializarObjetoDatos(CrearColeccionComplejo(5), "xml");
        }

        [TestMethod, TestCategory("Serializacion Coleccion ObjetoDatos")]
        public void SerializarObjetoDatosSimpleEnBinario()
        {
            SerializarObjetoDatos(CrearColeccionSimple(5), "bin");
        }

        [TestMethod, TestCategory("Serializacion Coleccion ObjetoDatos")]
        public void SerializarObjetoDatosComplejoEnBinario()
        {
            SerializarObjetoDatos(CrearColeccionComplejo(5), "bin");
        }
                
        void SerializarObjetoDatos(IObjetoDatos[] items, string formato)
        {
            ITipo tipo = items[0].Tipo;
            List<IObjetoDatos> items2 = new List<IObjetoDatos>();

            // serializar
            Serializar(items, formato);
            // deserializar
            Deserializar(tipo, items2, formato);
            // evaluar
            Evaluar(items, items2.ToArray());
        }

        void Evaluar(IObjetoDatos[] items1, IObjetoDatos[] items2)
        {
            Assert.AreEqual(items1.Length, items2.Length);

            for (int i = 0; i < items1.Length; i++)
                Assert.IsTrue(EqualityHelper.Instancia.Igual(items1[i], items2[i]));
        }

        #region CrearColeccion
        IObjetoDatos[] CrearColeccionSimple(int items)
        {
            IObjetoDatos[] od = new IObjetoDatos[items];

            for (int i = 0; i < items; i++)
                od[i] = CrearObjetoDatosSimple();

            return od;
        }

        IObjetoDatos[] CrearColeccionComplejo(int items)
        {
            IObjetoDatos[] od = new IObjetoDatos[items];

            for (int i = 0; i < items; i++)
                od[i] = CrearObjetoDatosComplejo();

            return od;
        }

        IObjetoDatos CrearObjetoDatosSimple()
        {
            IObjetoDatos od = TestHelper.Crear(HelperTipo.ObtenerTipo());
            TestHelper.Construir(od);
            return od;
        }

        IObjetoDatos CrearObjetoDatosComplejo()
        {
            IObjetoDatos od = TestHelper.Crear(HelperTipo.ObtenerTipo2());
            TestHelper.Construir(od, 2, 3);
            return od;
        }
        #endregion


        #region Serializacion
        void Serializar(IObjetoDatos[] items, string formato)
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
                
        void Serializar(IObjetoDatos[] items, ISecuencia secuencia, IEscritor escritor)
        {
            Serializador serializador = new SerializadorObjetoDatos(secuencia, escritor);
            serializador.Serializar(items);
        }

        void Deserializar(ITipo tipo, List<IObjetoDatos> items, string formato)
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

        void Deserializar(ITipo tipo, List<IObjetoDatos> items, ISecuencia secuencia, ILector lector)
        {
            Deserializador deserializador = new DeserializadorObjetoDatos(secuencia, lector);
            deserializador.Deserializar(tipo, items);
        }
        #endregion

    }
}
